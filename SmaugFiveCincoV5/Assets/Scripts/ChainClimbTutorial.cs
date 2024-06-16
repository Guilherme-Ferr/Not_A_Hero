using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChainClimbTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            tutorialTextMesh.text = "Escale correntes segurando as setas verticais do teclado.";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialTextMesh.text = null;
        }
    }
}

