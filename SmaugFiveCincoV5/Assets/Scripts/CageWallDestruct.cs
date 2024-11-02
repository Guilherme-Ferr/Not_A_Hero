using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageWallDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu é o projétil
        if (collision.gameObject.CompareTag("Projetil"))
        {
            // Ativa o sistema de partículas
            // Instantiate(estilhaços, transform.position, Quaternion.identity);

            // Destroi o projétil
            Destroy(collision.gameObject);

            // Destroi a parede
            // playerSound.PlayWallDestroyed();
            Destroy(transform.gameObject);
            // destroyed = true;
        }
    }
}
