using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField]
    private WorldChunk[] chunks;
    [SerializeField]
    private int centerObject = 2;
    public static float chunkSize;
    
    public void TryShift(int newIndex)
    {
        if (newIndex != centerObject)
        {
            if (newIndex == centerObject + 1 ||
                newIndex == (centerObject + 1) % chunks.Length)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
    }
    public void MoveRight()
    {
        int oldChunkIndex = centerObject - 2;
        if (oldChunkIndex < 0)
        {
            oldChunkIndex += chunks.Length;
        }
        Transform currentChunk = chunks[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.x += chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject++;
        centerObject = centerObject % chunks.Length;
    }

    public void MoveLeft()
    {
        int oldChunkIndex = centerObject + 2;
        oldChunkIndex = oldChunkIndex % chunks.Length;
        Transform currentChunk = chunks[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.x -= chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += chunks.Length;
        }
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
        Vector3 newPos = currentChunk.position;
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

    public int GetCenterObject()
    {
        return centerObject;
    }
}