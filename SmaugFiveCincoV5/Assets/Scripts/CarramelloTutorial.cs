using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarramelloTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            tutorialTextMesh.text = "Pressione F para falar com Caramello.";
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
