using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BiomeType
{
    Desert, Marsh, Rocky, Forest, Snow
}
public class WorldChunk : MonoBehaviour
{
    public int index = 0;
    public Vector2 chunkIndex;
    [SerializeField]
    private BiomeType biome;
    public bool inChunk = false;

    private Row row;

    void Start()
    {
        row = transform.parent.GetComponent<Row>();
        chunkIndex = new Vector2(index, row.index);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Wrapper.TryShiftColumn(index);
        }
    }


    public BiomeType GetBiomeType()
    {
        return biome;
    }
}
