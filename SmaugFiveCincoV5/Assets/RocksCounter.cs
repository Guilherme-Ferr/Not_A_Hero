using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocksCounter : MonoBehaviour
{
    public Slingshot slingshot;
    public TextMeshProUGUI rockCounterTextMesh;

    void Update()
    {
        rockCounterTextMesh.text = slingshot.pedras.ToString();
    }
}
