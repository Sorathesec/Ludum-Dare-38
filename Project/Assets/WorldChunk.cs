﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BiomeType
{
    Desert, Marsh, Rocky, Forest, Snow
}
public class WorldChunk : MonoBehaviour
{
    [SerializeField]
    private Vector2 chunkIndex;
    [SerializeField]
    private BiomeType biome;

    public BiomeType GetBiomeType()
    {
        return biome;
    }
    
    public Vector2 GetChunkIndex()
    {
        return chunkIndex;
    }
}
