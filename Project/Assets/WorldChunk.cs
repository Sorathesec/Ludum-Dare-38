using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    public int index = 0;
    public Vector2 chunkIndex;

    private Row row;

    void Start()
    {
        row = transform.parent.GetComponent<Row>();
        chunkIndex = new Vector2(index, row.index);
    }
}
