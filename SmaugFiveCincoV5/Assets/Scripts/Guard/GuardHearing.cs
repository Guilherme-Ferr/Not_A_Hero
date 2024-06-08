using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHearing : MonoBehaviour
{
    public GuardData guard;
    private PlayerSound playerSound;

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         playerSound = other.gameObject.GetComponent<PlayerSound>();
    //         if (playerSound.playerNoise == PlayerSound.PlayerNoise.mid || playerSound.playerNoise == PlayerSound.PlayerNoise.loud)
    //         {
    //             Debug.Log("houve sim");
    //             guard.canHearPlayer = true;
    //         }
    //         //tirar
    //         Debug.Log("houve sim");
    //         guard.canHearPlayer = true;
    //         guard.canHearPlayer = true;
    //         guard.aggro = true;
    //         //tirar
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("nao houve");
    //         guard.canHearPlayer = false;
    //         guard.aggro = false;
    //     }
    // }
}
