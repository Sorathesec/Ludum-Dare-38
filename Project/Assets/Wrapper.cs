using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public GameObject[] objects;
    public int centerObject = 2;
    public int chunkSize = 2;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        */
	}

    private void MoveRight()
    {
        int oldChunkIndex = centerObject - 2;
        if (oldChunkIndex < 0)
        {
            oldChunkIndex += objects.Length;
        }
        GameObject currentChunk = objects[oldChunkIndex];
        Vector3 newPos = currentChunk.transform.position;
        newPos.x += chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject++;
        centerObject = centerObject % objects.Length;
    }

    private void MoveLeft()
    {
        int oldChunkIndex = centerObject + 2;
        oldChunkIndex = oldChunkIndex % objects.Length;
        GameObject currentChunk = objects[oldChunkIndex];
        Vector3 newPos = currentChunk.transform.position;
        newPos.x -= chunkSize * 5;
        currentChunk.transform.position = newPos;
        centerObject--;
        if (centerObject < 0)
        {
            centerObject += objects.Length;
        }
    }
}
