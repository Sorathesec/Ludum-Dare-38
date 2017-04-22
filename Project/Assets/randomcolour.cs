using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcolour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Color col = GetComponent<SpriteRenderer>().color;

        col.r = Random.Range(0.0f, 1.0f);
        col.g = Random.Range(0.0f, 1.0f);
        col.b = Random.Range(0.0f, 1.0f);

        GetComponent<SpriteRenderer>().color = col;
    }
}
