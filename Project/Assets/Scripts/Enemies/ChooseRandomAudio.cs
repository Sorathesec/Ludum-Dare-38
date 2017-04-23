using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] damageClips;
    [SerializeField]
    private AudioClip[] deathClips;
    // Use this for initialization
    void Start ()
    {
        ZombieHealth health = GetComponent<ZombieHealth>();
        int rnd = Random.Range(0, damageClips.Length);
        health.SetDamageClip(damageClips[rnd]);
        health.SetDeathClip(deathClips[rnd]);
	}
}
