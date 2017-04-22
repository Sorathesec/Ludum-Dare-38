using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public WorldChunk[] objects;
    public int centerObject = 2;
    public int chunkSize = 2;

    private static Wrapper instance;

	void Start ()
    {
        instance = this;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].index = i;
        }
	}

    public static void TryShift(int index)
    {
        if(index != instance.centerObject)
        {
            if(index == instance.centerObject + 1 || 
                index == (instance.centerObject + 1) % instance.objects.Length)
            {
                instance.MoveRight();
            }
            else
            {
                instance.MoveLeft();
            }
        }
    }

    public void MoveRight()
    {
        int oldChunkIndex = centerObject - 2;
        if (oldChunkIndex < 0)
        {
            oldChunkIndex += objects.Length;
        }
        Transform currentChunk = objects[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.x += chunkSize * 5;
        currentChunk.position = newPos;
        centerObject++;
        centerObject = centerObject % objects.Length;
    }

    public void MoveLeft()
    {
        int oldChunkIndex = centerObject + 2;
        oldChunkIndex = oldChunkIndex % objects.Length;
        Transform currentChunk = objects[oldChunkIndex].transform;
        Vector3 newPos = currentChunk.position;
        newPos.x -= chunkSize * 5;
        currentChunk.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += objects.Length;
        }
    }
}
