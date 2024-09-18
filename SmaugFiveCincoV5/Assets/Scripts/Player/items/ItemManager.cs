using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // public enum CollectableItems { Potato, Melon, Banana, Apple }
    // public GameObject carriedItem1 = null;
    // public GameObject carriedItem2 = null;
    // public GameObject carriedItem3 = null;
    // public GameObject carriedItem4 = null;
    // public GameObject carriedItem5 = null;
    // public Image slot1 = null;
    // public Image slot2 = null;
    // public Image slot3 = null;
    // public Image slot4 = null;
    // public Image slot5 = null;
    // private bool isCollecting = false;
    // private bool isDroping = false;
    // private bool isChangingItem = false;

    // [SerializeField] public PlayerData player;
    // [SerializeField] public GameObject storage;
    // [SerializeField] public PlayerSound playerSound;

    // Dictionary<KeyCode, int> keyToItemPosition = new Dictionary<KeyCode, int>
    // {
    //     { KeyCode.Alpha1, 0 },
    //     { KeyCode.Alpha2, 1 },
    //     { KeyCode.Alpha3, 2 },
    //     { KeyCode.Alpha4, 3 },
    //     { KeyCode.Alpha5, 4 }
    // };

    // private void Update()
    // {
    //     DropItem();
    //     ChangeItemSelected();
    // }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Collectable"))
    //     {
    //         if (Input.GetKey(KeyCode.F) && !isCollecting)
    //         {
    //             CollectItem(collision.gameObject);
    //         }
    //     }
    // }

    // private void CollectItem(GameObject gameObject)
    // {
    //     isCollecting = true;
    //     SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    //     if (carriedItem1 == null)
    //     {
    //         carriedItem1 = gameObject;
    //         slot1.sprite = spriteRenderer.sprite;
    //         slot1.color = spriteRenderer.color;
    //         gameObject.SetActive(false);
    //         playerSound.PlayCollectVegetation();
    //     }
    //     else if (carriedItem2 == null)
    //     {
    //         carriedItem2 = gameObject;
    //         slot2.sprite = spriteRenderer.sprite;
    //         slot2.color = spriteRenderer.color;
    //         gameObject.SetActive(false);
    //         playerSound.PlayCollectVegetation();
    //     }
    //     else if (carriedItem3 == null)
    //     {
    //         carriedItem3 = gameObject;
    //         slot3.sprite = spriteRenderer.sprite;
    //         slot3.color = spriteRenderer.color;
    //         gameObject.SetActive(false);
    //         playerSound.PlayCollectVegetation();
    //     }
    //     else if (carriedItem4 == null)
    //     {
    //         carriedItem4 = gameObject;
    //         slot4.sprite = spriteRenderer.sprite;
    //         slot4.color = spriteRenderer.color;
    //         gameObject.SetActive(false);
    //         playerSound.PlayCollectVegetation();
    //     }
    //     else if (carriedItem5 == null)
    //     {
    //         carriedItem5 = gameObject;
    //         slot5.sprite = spriteRenderer.sprite;
    //         slot5.color = spriteRenderer.color;
    //         gameObject.SetActive(false);
    //         playerSound.PlayCollectVegetation();
    //     }
    //     isCollecting = false;
    // }

    // private void ChangeItemSelected()
    // {
    //     if (!isChangingItem)
    //     {
    //         foreach (var kvp in keyToItemPosition)
    //         {
    //             if (Input.GetKey(kvp.Key))
    //             {
    //                 player.itemSelectedPosition = kvp.Value;
    //                 isChangingItem = true;
    //                 break;
    //             }
    //         }
    //         isChangingItem = false;
    //     }
    // }

    // private void DropItem()
    // {
    //     if (Input.GetKey(KeyCode.G) && !isDroping)
    //     {
    //         GameObject dropedItem = null;
    //         Image slotActive = null;
    //         switch (player.itemSelectedPosition)
    //         {
    //             case 0:
    //                 dropedItem = carriedItem1;
    //                 slotActive = slot1;
    //                 break;
    //             case 1:
    //                 dropedItem = carriedItem2;
    //                 slotActive = slot2;
    //                 break;
    //             case 2:
    //                 dropedItem = carriedItem3;
    //                 slotActive = slot3;
    //                 break;
    //             case 3:
    //                 dropedItem = carriedItem4;
    //                 slotActive = slot4;
    //                 break;
    //             case 4:
    //                 dropedItem = carriedItem5;
    //                 slotActive = slot5;
    //                 break;
    //             default: break;
    //         }
    //         if (dropedItem != null)
    //         {
    //             isDroping = true;
    //             dropedItem.SetActive(true);
    //             slotActive.sprite = null;
    //             slotActive.color = Color.black;
    //             dropedItem.transform.position = transform.position;

    //             switch (player.itemSelectedPosition)
    //             {
    //                 case 0:
    //                     carriedItem1 = null;
    //                     break;
    //                 case 1:
    //                     carriedItem2 = null;

    //                     break;
    //                 case 2:
    //                     carriedItem3 = null;
    //                     break;
    //                 case 3:
    //                     carriedItem4 = null;
    //                     break;
    //                 case 4:
    //                     carriedItem5 = null;
    //                     break;
    //                 default: break;
    //             }
    //         }
    //         isDroping = false;
    //     }
    // }
}
