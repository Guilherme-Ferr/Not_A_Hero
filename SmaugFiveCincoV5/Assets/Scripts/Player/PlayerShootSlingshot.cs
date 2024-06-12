using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSlingshot : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public PlayerData player;
    [SerializeField] public PlayerSound playerSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ShootgSlingshot();
    }

    private void ShootgSlingshot()
    {
        if (Input.GetKey(KeyCode.Z) && player.collectedSlingshot && (
                player.state == PlayerData.PlayerMovementState.idleSlingshot ||
                player.state == PlayerData.PlayerMovementState.walkingSlingshot ||
                player.state == PlayerData.PlayerMovementState.runningSlingshot ||
                player.state == PlayerData.PlayerMovementState.landingSlingshot
            )
        )
        {
            rb.bodyType = RigidbodyType2D.Static;
            player.state = PlayerData.PlayerMovementState.shootingSlingshot;
            playerSound.PlaySlingShoot();
        }
    }
}
