using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDivManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialTextMesh;
    public GameObject image;

    void Update()
    {
        if (tutorialTextMesh.text == null)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
    }
}
