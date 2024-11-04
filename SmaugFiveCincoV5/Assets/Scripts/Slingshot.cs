using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject pedraPrefab;  // O prefab da pedra
    public Transform pontoDeDisparo; // O ponto de onde a pedra será disparada
    public float forcaDeDisparo = 10f; // A força com que a pedra será disparada
    public int pedras = 0; // A quantidade inicial de pedras
    public PlayerData player;

    public void Atirar()
    {
        pedras--;

        Vector3 posicaoDisparo = pontoDeDisparo.position;

        float deslocamentoX = 2f;

        if (player.facingSide == PlayerData.FacingSide.right)
        {
            // Soma 1.7 no eixo X se o player estiver virado para a direita
            posicaoDisparo.x += deslocamentoX;
        }
        else if (player.facingSide == PlayerData.FacingSide.left)
        {
            // Subtrai 1.7 no eixo X se o player estiver virado para a esquerda
            posicaoDisparo.x -= deslocamentoX;
        }

        GameObject pedra = Instantiate(pedraPrefab, posicaoDisparo, pontoDeDisparo.rotation);

        Rigidbody2D rb = pedra.GetComponent<Rigidbody2D>();

        if (player.facingSide == PlayerData.FacingSide.right)
        {
            rb.AddForce(pontoDeDisparo.right * forcaDeDisparo, ForceMode2D.Impulse);
        }
        else if (player.facingSide == PlayerData.FacingSide.left)
        {
            rb.AddForce(-pontoDeDisparo.right * forcaDeDisparo, ForceMode2D.Impulse);
        }

    }
}
