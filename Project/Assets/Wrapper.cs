using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public Row[] rows;
    public int centerObject = 2;
    public float chunkSize = 2;

    private static Wrapper instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rows = GetComponentsInChildren<Row>();
        centerObject = rows.Length / 2;
        if (centerObject == rows.Length / 2.0f)
        {
            centerObject--;
        }
        Row.chunkSize = chunkSize;
        int i = 0;
        foreach (Row row in rows)
        {
            row.index = i;
            i++;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 temp = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().currentChunk;
        if (temp != new Vector2(centerObject, rows[0].centerObject))
        {
            TryShiftColumn((int)temp.x);
            TryShiftRow((int)temp.y);
        }
    }

    public static void TryShiftColumn(int index)
    {
        foreach(Row row in instance.rows)
        {
            row.SendMessage("TryShift", index);
        }        
    }

    public static void TryShiftRow(int index)
    {
        if (index != instance.centerObject)
        {
            if (index == instance.centerObject + 1 ||
                index == (instance.centerObject + 1) % instance.rows.Length)
            {
                instance.MoveUp();
            }
            else
            {
                instance.MoveDown();
            }
        }
    }

    private void MoveUp()
    {
        int oldChunkIndex = centerObject - 2;
        if (oldChunkIndex < 0)
        {
            oldChunkIndex += rows.Length;
        }
        Transform currentChunk = rows[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.y += chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject++;
        centerObject = centerObject % rows.Length;
    }

    private void MoveDown()
    {
        int oldChunkIndex = centerObject + 2;
        oldChunkIndex = oldChunkIndex % rows.Length;

        Transform currentChunk = rows[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.y -= chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += rows.Length;
        }
    }
}