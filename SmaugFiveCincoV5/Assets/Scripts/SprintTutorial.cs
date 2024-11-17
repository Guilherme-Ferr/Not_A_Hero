using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SprintTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            tutorialTextMesh.text = "Use SHIFT para correr.";
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
