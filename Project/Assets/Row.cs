using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private WorldChunk[] chunks;
    private int centerObject;
    public static int chunkSize;
    public int index = 0;

    // Use this for initialization
    void Start()
    {
        chunks = GetComponentsInChildren<WorldChunk>();

        centerObject = chunks.Length / 2;
        if (centerObject == chunks.Length / 2.0f)
        {
            centerObject--;
        }
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].index = i;
        }
    }

    public void TryShift(int index)
    {
        if (index != centerObject)
        {
            if (index == centerObject + 1 ||
                index == (centerObject + 1) % chunks.Length)
            {
                MoveColumn(1);
            }
            else
            {
                MoveColumn(-1);
            }
        }
    }

    public void TryShiftRow()
    {
        Wrapper.TryShiftRow(index);
    }

    private void MoveColumn(int multiplier)
    {
        int oldChunkIndex = centerObject - (2 * multiplier);
        if (multiplier > 0)
        {
            if (oldChunkIndex < 0)
            {
                oldChunkIndex += chunks.Length;
            }
        }
        else
        {
            oldChunkIndex = oldChunkIndex % chunks.Length;
        }
        Transform currentChunk = chunks[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.transform.position;
        newPos.x += chunkSize * 5 * multiplier;
        currentChunk.transform.position = newPos;
        centerObject += 1 * multiplier;
        if (multiplier > 0)
        {
            centerObject = centerObject % chunks.Length;
        }
        else
        {
            if (centerObject < 0)
            {
                centerObject += chunks.Length;
            }
        }
    }
}