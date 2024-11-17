using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrouchTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            tutorialTextMesh.text = "Use CONTROL para andar silenciosamente.";
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
