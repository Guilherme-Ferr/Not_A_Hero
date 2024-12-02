using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectTorch : MonoBehaviour
{
    public Transform torchLight;
    public AudioSource keyCollectSoundEffect;
    public TextMeshProUGUI torchQuantity;
    private PlayerData player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject.GetComponent<PlayerData>();
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            player.collectedTorch = true;
            player.state = PlayerData.PlayerMovementState.idleTorch;
            rb.bodyType = RigidbodyType2D.Dynamic;
            keyCollectSoundEffect.Play();
            torchLight.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
            torchQuantity.text = "1";
        }
    }

    void Update()
    {
        if (player.collectedTorch == false)
        {
            torchQuantity.text = "0";
        }
        else
        {
            torchQuantity.text = "1";
        }
    }

    public void resetTorch()
    {
        torchLight.gameObject.SetActive(true);
        transform.gameObject.SetActive(true);
    }
}
