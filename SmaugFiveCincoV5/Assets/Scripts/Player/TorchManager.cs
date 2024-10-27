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
    public AudioSource torchOnSoundEffect;
    public AudioSource torchContinuousSoundEffect;

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

        if (Input.GetKeyDown(KeyCode.X) && player.collectedTorch && !player.isInWaterfall)
        {
            player.withTorch = !player.withTorch;
            if (!player.withTorch)
            {
                torchOffSoundEffect.Play();
                torchContinuousSoundEffect.Stop();
                torchOnSoundEffect.Stop();
            }
            else
            {
                torchOnSoundEffect.Play();
                StartCoroutine(PlayContinuousSoundAfter(torchOnSoundEffect.clip.length));
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

    private IEnumerator PlayContinuousSoundAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (player.withTorch) // Verificar se a tocha ainda está ligada
        {
            torchContinuousSoundEffect.Play();
        }
    }
}
