using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFallSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform player;
    public float maxDistance = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // Set to 3D
        audioSource.minDistance = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.loop = true;

        if (audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Audio started playing.");
        }
        else
        {
            Debug.LogError("No audio clip assigned to the AudioSource.");
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log($"Distance to player: {distance}");
        Debug.Log($"maxDistance: {maxDistance}");
        Debug.Log($"!audioSource.isPlaying: {!audioSource.isPlaying}");

        if (distance <= maxDistance && !audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Audio playing.");
        }
        else if (distance > maxDistance && audioSource.isPlaying)
        {
            audioSource.Pause();
            Debug.Log("Audio paused.");
        }
    }
}
