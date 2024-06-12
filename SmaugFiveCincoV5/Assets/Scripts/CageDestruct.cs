using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestruct : MonoBehaviour
{
    public PlayerData player;
    [SerializeField] public PlayerSound playerSound;

    public void DestroyWall()
    {
        if (player.state == PlayerData.PlayerMovementState.shootingSlingshot && player.facingSide == PlayerData.FacingSide.right)
        {
            Destroy(transform.gameObject);
            playerSound.PlayWallDestroyed();
        }
    }
}
