using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    public int index = 0;

    private Row row;

    void Start()
    {
        row = transform.parent.GetComponent<Row>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Wrapper.TryShiftColumn(index);
            Wrapper.TryShiftRow(row.index);
        }
    }
}
