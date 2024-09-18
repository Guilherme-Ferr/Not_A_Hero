using UnityEngine;

public class GrassPickup : MonoBehaviour
{
    public Transform grass; // O item que será carregado
    public Transform carryPosition; // O local onde o item ficará ao ser carregado (acima do personagem)
    public bool isCarrying = false; // Verifica se o item está sendo carregado
    private Vector2 originalPosition; // Guarda a posição original do item

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isCarrying)
            {
                DropGrass(); // Solta o item
            }
            else
            {
                TryPickupGrass(); // Tenta pegar o item
            }
        }
    }

    void TryPickupGrass()
    {
        // Detecta se o personagem está sobre o item (usando distância ou colisão)
        float distance = Vector2.Distance(transform.position, grass.position);
        if (distance < 1.5f) // Exemplo de raio de alcance para pegar o item
        {
            isCarrying = true;
            originalPosition = grass.position; // Armazena a posição original do item
            grass.SetParent(transform); // O item se torna "filho" do personagem
            grass.position = carryPosition.position; // Move o item para a posição acima do personagem
        }
    }

    public void DropGrass()
    {
        isCarrying = false;
        grass.SetParent(null); // Remove o item do personagem
                               // Aqui você pode soltar o item no chão (posição atual, ou outra)
                               // Solta o item na posição original Y e na posição atual X
        grass.position = new Vector2(transform.position.x, originalPosition.y);
    }
}
