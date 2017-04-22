using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour
{
    [SerializeField]
    private BiomeType[] biomes;
    [SerializeField]
    private Sprite[] sprites;

    private new SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(BiomeType biome)
    {
        for(int i = 0; i < biomes.Length; i++)
        {
            if(biomes[i] == biome)
            {
                renderer.sprite = sprites[i];
            }
        }
    }
}
