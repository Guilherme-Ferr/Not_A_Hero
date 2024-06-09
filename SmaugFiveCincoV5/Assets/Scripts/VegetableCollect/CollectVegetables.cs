using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectVegetables : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public int totalItemsNeeded = 5;
    public int totalItemsDelivered = 0;
    public bool finishedCollecting = false;
    private bool isDroping = false;

    private void Update()
    {
        if (textMesh != null)
        {
            if (totalItemsDelivered < totalItemsNeeded)
            {
                textMesh.text = "Colete e guarde em seu baú suas plantações " + totalItemsDelivered + "/" + totalItemsNeeded;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isDroping)
        {
            isDroping = true;
            ItemManager playerItems = collider.gameObject.GetComponent<ItemManager>();

            GameObject[] itemsList = { playerItems.carriedItem1, playerItems.carriedItem2, playerItems.carriedItem3, playerItems.carriedItem4, playerItems.carriedItem5 };
            Image[] slotsList = { playerItems.slot1, playerItems.slot2, playerItems.slot3, playerItems.slot4, playerItems.slot5 };

            foreach (var item in itemsList)
            {
                if (item != null)
                {
                    // ItemManager.CollectableItems itemType = item.GetComponent<Collectable>().collectableType;

                    // Debug.Log("tem uma " + itemType + " no borso");

                    VerifyTotalItemsCollected();
                }
            }

            // for (int item = 0; item < itemsList.Length; item++)
            // {
            //     // }

            //     // foreach (var item in itemsList)
            //     // {
            //     if (itemsList[item] != null)
            //     {
            //         // ItemManager.CollectableItems itemType = itemsList[item].GetComponent<Collectable>().collectableType;

            //         // Debug.Log("tem uma " + itemType + " no borso");

            //         // GameObject vapo = itemsList[item];

            //         // vapo = null;

            //         // itemsList[item] = null;
            //         // slotsList[item].sprite = null;
            //         // slotsList[item].color = Color.black;
            //         VerifyTotalItemsCollected();
            //     }
            // }

            playerItems.carriedItem1 = null;
            playerItems.carriedItem2 = null;
            playerItems.carriedItem3 = null;
            playerItems.carriedItem4 = null;
            playerItems.carriedItem5 = null;
            playerItems.slot1.sprite = null;
            playerItems.slot1.color = Color.black;
            playerItems.slot2.sprite = null;
            playerItems.slot2.color = Color.black;
            playerItems.slot3.sprite = null;
            playerItems.slot3.color = Color.black;
            playerItems.slot4.sprite = null;
            playerItems.slot4.color = Color.black;
            playerItems.slot5.sprite = null;
            playerItems.slot5.color = Color.black;

            // playerItems.carriedItem1 = null;
            // playerItems.carriedItem2 = null;
            // playerItems.carriedItem3 = null;
            // playerItems.carriedItem4 = null;
            // playerItems.carriedItem5 = null;

            // slotsList.s




            // Collider2D collider2 = transform.GetComponent<Collider2D>();

            // if (collider1.bounds.Intersects(collider2.bounds))
            // {
            //     // Os objetos estão se sobrepondo
            //     Debug.Log("Os objetos estão se sobrepondo.");
            // }
            // else
            // {
            //     // Os objetos não estão se sobrepondo
            //     Debug.Log("Os objetos não estão se sobrepondo.");
            // }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isDroping = false;
    }

    private void VerifyTotalItemsCollected()
    {
        totalItemsDelivered++;
        if (totalItemsNeeded == totalItemsDelivered)
        {
            textMesh.text = "Volte para sua casa";
            finishedCollecting = true;
        }
    }
}
