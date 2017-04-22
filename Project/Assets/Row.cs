using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Transform[] chunks;
    private int centerObject;
    public static int chunkSize;

    // Use this for initialization
    void Start()
    {
        Transform[] temp = GetComponentsInChildren<Transform>();
        chunks = new Transform[temp.Length - 1];
        int i = 0;
        foreach (Transform trans in temp)
        {
            if (trans != transform)
            {
                chunks[i] = trans;
                i++;
            }
        }
        print(chunks.Length);
        centerObject = chunks.Length / 2;
        if (centerObject == chunks.Length / 2.0f)
        {
            centerObject--;
        }
    }
    public void MoveRight()
    {
        int oldChunkIndex = centerObject - 2;
        if (oldChunkIndex < 0)
        {
            oldChunkIndex += chunks.Length;
        }
        Transform currentChunk = chunks[oldChunkIndex];
        Vector3 newPos = currentChunk.transform.position;
        newPos.x += chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject++;
        centerObject = centerObject % chunks.Length;
    }

    public void MoveLeft()
    {
        int oldChunkIndex = centerObject + 2;
        oldChunkIndex = oldChunkIndex % chunks.Length;
        Transform currentChunk = chunks[oldChunkIndex];
        Vector3 newPos = currentChunk.transform.position;
        newPos.x -= chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += chunks.Length;
        }
    }
}