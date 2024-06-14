using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLeakSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource prisonMusicAudioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "WaterLeakSoundOn" && !audioSource.isPlaying)
            {
                audioSource.Play();
                prisonMusicAudioSource.Stop();
            }
            else if (gameObject.name == "WaterLeakSoundOff" && audioSource.isPlaying)
            {
                audioSource.Stop();
                prisonMusicAudioSource.Play();
            }
        }
    }
}
