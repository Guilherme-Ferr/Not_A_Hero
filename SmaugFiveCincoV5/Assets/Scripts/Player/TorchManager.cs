using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchManager : MonoBehaviour
{
    public Light2D torchLight;
    public Light2D playerLight;
    public PlayerData player;

    void Start()
    {
        if (torchLight != null)
        {
            torchLight.enabled = false;
        }
    }

    void Update()
    {
        if (player.collectedTorch)
        {
            torchLight.enabled = player.withTorch;
        }

        if (Input.GetKeyDown(KeyCode.X) && player.collectedTorch)
        {
            player.withTorch = !player.withTorch;
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
