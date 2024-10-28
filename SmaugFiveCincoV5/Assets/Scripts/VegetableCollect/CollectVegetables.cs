using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectVegetables : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI tutorialTextMesh;
    public Transform grass;
    public GrassPickup grassPickup;

    public int totalItemsDelivered = 0;
    public bool finishedCollecting = false;

    private void Update()
    {
        if (textMesh != null)
        {
            if (!finishedCollecting)
            {
                textMesh.text = "Colete e guarde em seu baú sua plantação.";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player") && grassPickup.isCarrying)
        {

            finishedCollecting = true;
            textMesh.text = "Estenda suas roupas.";
            tutorialTextMesh.text = null;
            grassPickup.DropGrass();

            //tocar som de bau recheado
        }
    }
}
