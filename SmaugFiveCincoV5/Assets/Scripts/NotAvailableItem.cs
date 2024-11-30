using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotAvailableItem : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;
    public GameObject image;
    public PlayerData player;

    private void Update()
    {
        UseUnavailableItem();
    }

    private void UseUnavailableItem()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            image.SetActive(true);
            tutorialTextMesh.text = "Você não coletou o chroma key ainda";
            Invoke(nameof(ClearText), 5f);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            image.SetActive(true);
            tutorialTextMesh.text = "Você não coletou um mapa ainda";
            Invoke(nameof(ClearText), 5f);
        }

        if (Input.GetKeyDown(KeyCode.Z) && !player.collectedSlingshot)
        {
            image.SetActive(true);
            tutorialTextMesh.text = "Você não coletou um estilingue ainda";
            Invoke(nameof(ClearText), 5f);
        }

        if (Input.GetKeyDown(KeyCode.X) && !player.collectedTorch)
        {
            image.SetActive(true);
            tutorialTextMesh.text = "Você não coletou uma tocha ainda";
            Invoke(nameof(ClearText), 5f);
        }
    }

    private void ClearText()
    {
        tutorialTextMesh.text = "";
        image.SetActive(false);
    }
}
