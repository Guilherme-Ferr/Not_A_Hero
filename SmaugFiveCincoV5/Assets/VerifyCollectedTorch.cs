using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VerifyCollectedTorch : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;


    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();

            if (!player.collectedTorch)
            {
                ShowCanvasNeedsTorch();
            }
        }
    }

    private void ShowCanvasNeedsTorch()
    {

    }
}
