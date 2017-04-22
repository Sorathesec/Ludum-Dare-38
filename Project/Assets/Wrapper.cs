using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public Row[] rows;
    public int centerObject = 2;
    public int chunkSize = 2;

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
    public static void TryShiftColumn(int index)
    {
        foreach(Row row in instance.rows)
        {
            row.TryShift(index);
        }        
    }
    public static void TryShiftRow(int index)
    {
        if (index != instance.centerObject)
        {
            if (index == instance.centerObject + 1 ||
                index == (instance.centerObject + 1) % instance.rows.Length)
            {
                instance.MoveRow(1);
            }
            else
            {
                instance.MoveRow(-1);
            }
        }
    }
    private void MoveRow(int multiplier)
    {
        int oldChunkIndex = centerObject - (2 * multiplier);
        if(multiplier > 0)
        {
            if (oldChunkIndex < 0)
            {
                oldChunkIndex += rows.Length;
            }
        }
        else
        {
            oldChunkIndex = oldChunkIndex % rows.Length;
        }
        Transform currentChunk = rows[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.transform.position;
        newPos.y += chunkSize * 5 * multiplier;
        currentChunk.transform.position = newPos;
        centerObject += 1 * multiplier;
        if (multiplier > 0)
        {
            centerObject = centerObject % rows.Length;
        }
        else
        {
            if (centerObject < 0)
            {
                centerObject += rows.Length;
            }
        }
    }
}