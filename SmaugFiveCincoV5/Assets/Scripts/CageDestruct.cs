using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestruct : MonoBehaviour
{
    public PlayerData player;

    // Update is called once per frame
    void Update()
    {
        if (player.state == PlayerData.PlayerMovementState.shootingSlingshot && player.facingSide == PlayerData.FacingSide.right)
        {
            Destroy(transform.gameObject);
        }
    }
}
