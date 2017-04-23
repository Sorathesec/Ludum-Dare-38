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
        IsShootable shootable = GetComponent<IsShootable>();
        int rnd = Random.Range(0, damageClips.Length);
        shootable.damageClip = damageClips[rnd];
        shootable.deathClip = deathClips[rnd];
	}
}
