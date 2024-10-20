using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSlingshot : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public PlayerData player;
    [SerializeField] public PlayerSound playerSound;
    [SerializeField] public CageDestruct cageWall;
    [SerializeField] public Slingshot slingshot;

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
        if (Input.GetKeyDown(KeyCode.Z) && player.collectedSlingshot && slingshot.pedras > 0 && rb.bodyType == RigidbodyType2D.Dynamic && (
                player.state == PlayerData.PlayerMovementState.idleSlingshot ||
                player.state == PlayerData.PlayerMovementState.walkingSlingshot ||
                player.state == PlayerData.PlayerMovementState.runningSlingshot ||
                player.state == PlayerData.PlayerMovementState.landingSlingshot
            )
        )
        {
            player.state = player.withTorch ? PlayerData.PlayerMovementState.shootingSlingshotTorch : PlayerData.PlayerMovementState.shootingSlingshot;
            playerSound.PlaySlingShoot();
        }
    }

    public void BreakWall()
    {
        cageWall.DestroyWall();
    }
}
