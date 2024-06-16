using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerifyCollectedTorch : MonoBehaviour
{
    public Transform torchBlocker;
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();

            if (!player.collectedTorch)
            {
                tutorialTextMesh.text = "Estã muito escuro adiante, é necessario uma tocha para avançar.";
            }
            else
            {
                tutorialTextMesh.text = null;
                Destroy(torchBlocker.gameObject);
                Destroy(transform.gameObject);
            }
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
