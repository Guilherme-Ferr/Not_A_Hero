using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBirds : MonoBehaviour
{
    public AudioClip[] sounds;
    public float interval = 5.0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        InvokeRepeating("PlaySound", 5, interval);
    }

    void PlaySound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];
        audioSource.volume = 0.2f;
        audioSource.clip = randomSound;
        audioSource.Play();
    }
}
