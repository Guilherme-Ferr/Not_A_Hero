using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingBridge : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public PlayerData player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClimbBridge"))
        {
            ClimbBridge();
        }
    }

    private void ClimbBridge()
    {
        // if()
        Debug.Log("animação escalada de ponte");
        //trava o boneco 
        //define true pra var q trava 

        // rb.bodyType = RigidbodyType2D.Static;
        // player.state = PlayerData.PlayerMovementState.shootingSlingshot;
    }
}
