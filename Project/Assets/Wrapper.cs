using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public Row[] rows;
    public int centerObject = 2;
    public int chunkSize = 2;
	
    void Start()
    {
        rows = GetComponentsInChildren<Row>();
        centerObject = rows.Length / 2;
        if(centerObject == rows.Length / 2.0f)
        {
            centerObject--;
        }
        Row.chunkSize = chunkSize;
    }

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
	}

    private void MoveRight()
    {
        foreach(Row row in rows)
        {
            row.MoveRight();
        }
    }

    private void MoveLeft()
    {
        foreach (Row row in rows)
        {
            row.MoveLeft();
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
        Vector3 newPos = currentChunk.transform.position;
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
        Vector3 newPos = currentChunk.transform.position;
        newPos.y -= chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += rows.Length;
        }
    }
}