using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPeopleSound : MonoBehaviour
{
    public AudioSource peopleSoundEffect;

    void Start()
    {
        peopleSoundEffect.Play();
    }
}
