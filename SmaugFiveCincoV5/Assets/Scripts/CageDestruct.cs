using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestruct : MonoBehaviour
{
    public PlayerData player;
    [SerializeField] public PlayerSound playerSound;
    private bool destroyed = false;

    public void DestroyWall()
    {
        if (player.state == PlayerData.PlayerMovementState.shootingSlingshot && player.facingSide == PlayerData.FacingSide.right && !destroyed)
        {
            playerSound.PlayWallDestroyed();
            Destroy(transform.gameObject);
            destroyed = true;
        }
    }
}
