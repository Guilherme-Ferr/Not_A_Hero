using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchManager : MonoBehaviour
{
    public Light2D torchLight;
    public Light2D playerLight;
    public PlayerData player;
    public AudioSource torchOffSoundEffect;

    void Start()
    {
        if (torchLight != null)
        {
            torchLight.enabled = false;
        }
    }

    void Update()
    {
        TurnTorch();
    }

    private void TurnTorch()
    {
        if (player.collectedTorch)
        {
            torchLight.enabled = player.withTorch;
        }

        if (Input.GetKeyDown(KeyCode.X) && player.collectedTorch)
        {
            player.withTorch = !player.withTorch;
            if (!player.withTorch)
            {
                torchOffSoundEffect.Play();
            }
        }

        if (torchLight.enabled)
        {
            playerLight.enabled = false;
        }
        else
        {
            playerLight.enabled = true;
        }
    }
}
