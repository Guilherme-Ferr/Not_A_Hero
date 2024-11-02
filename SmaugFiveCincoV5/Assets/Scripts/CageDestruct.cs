using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestruct : MonoBehaviour
{
    public PlayerData player;
    // public GameObject cageWall;
    [SerializeField] public PlayerSound playerSound;
    private bool destroyed = false;

    public void DestroyWall()
    {
        if (player.state == PlayerData.PlayerMovementState.shootingSlingshot && player.facingSide == PlayerData.FacingSide.right && !destroyed)
        {
            playerSound.PlayWallDestroyed();
            Destroy(transform.gameObject);
            // Destroy(cageWall);
            destroyed = true;
        }
    }

    // public ParticleSystem estilhaços; // arraste o sistema de partículas aqui no Inspector

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Verifica se o objeto que colidiu é o projétil
    //     if (collision.gameObject.CompareTag("Projetil"))
    //     {
    //         // Ativa o sistema de partículas
    //         Instantiate(estilhaços, transform.position, Quaternion.identity);

    //         // Destroi o projétil
    //         // Destroy(collision.gameObject);

    //         // Destroi a parede
    //         playerSound.PlayWallDestroyed();
    //         Destroy(transform.gameObject);
    //         // destroyed = true;
    //     }
    // }
}
