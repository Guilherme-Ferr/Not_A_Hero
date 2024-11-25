using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public GuardData guard;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !guard.canSeePlayer)
        {
            PlayerData playerdata = other.gameObject.GetComponent<PlayerData>();

            playerdata.isHiden = true;
            playerdata.gameObject.layer = LayerMask.NameToLayer("HiddenPlayer");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerData playerdata = other.gameObject.GetComponent<PlayerData>();

            playerdata.isHiden = false;

            playerdata.gameObject.layer = LayerMask.NameToLayer("Player");

        }
    }
}
