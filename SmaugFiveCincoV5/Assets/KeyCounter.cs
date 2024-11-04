using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    public TextMeshProUGUI keyCounterTextMesh;
    public int keys;

    void Update()
    {
        keyCounterTextMesh.text = keys.ToString();
    }
}
