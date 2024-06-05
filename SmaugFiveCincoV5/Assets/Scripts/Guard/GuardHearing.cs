using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHearing : MonoBehaviour
{
    public GuardData guard;
    private PlayerSound playerSound;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSound = other.gameObject.GetComponent<PlayerSound>();
            if (playerSound.playerNoise == PlayerSound.PlayerNoise.mid || playerSound.playerNoise == PlayerSound.PlayerNoise.loud)
            {
                guard.canHearPlayer = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guard.canHearPlayer = false;
        }
    }
}
