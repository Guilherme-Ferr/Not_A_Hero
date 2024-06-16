using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorchTurorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();

            if (player.collectedTorch)
            {
                tutorialTextMesh.text = "Pressione X para utilizar a tocha.";
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
