using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField]

    protected int pooledAmount;
    [SerializeField]
    protected GameObject objectPrefab;

    // Script logic
    private AudioSource[] objectPool;

    // Use this for initialization
    void Start()
    {
        instance = this;

        CreatePool();
    }

    /// <summary>
    /// Initialises the object pool and fills it with game objects made from the prefab given
    /// </summary>
    protected void CreatePool()
    {
        objectPool = new AudioSource[pooledAmount];

        GameObject temp;
        for (int i = 0; i < pooledAmount; i++)
        {
            temp = Instantiate(objectPrefab) as GameObject;
            temp.transform.parent = transform;
            objectPool[i] = temp.GetComponent<AudioSource>();
        }
    }
    /// <summary>
    /// Returns a gameobject from the local pool if there is one available
    /// </summary>
    /// <returns> The gameobject from the pool </returns>
    protected AudioSource GetPooledItem()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if (objectPool[i] != null && 
                !objectPool[i].isPlaying)
            {
                return objectPool[i];
            }
        }
        return null;
    }

    public static void PlayAudioClip(AudioClip audio)
    {
        AudioSource source = instance.GetPooledItem();
        
        source.PlayOneShot(audio);
    }
}
