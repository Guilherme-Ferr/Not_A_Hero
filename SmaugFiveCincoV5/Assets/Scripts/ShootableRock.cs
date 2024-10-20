using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableRock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Destrutível"))
        // {
        //     // Destrói o objeto destrutível
        //     Destroy(collision.gameObject);
        // }else
        if (collision.gameObject.CompareTag("PrisonFloor"))
        {
            // O projétil para na parede
            Destroy(gameObject);
        }
    }
}
