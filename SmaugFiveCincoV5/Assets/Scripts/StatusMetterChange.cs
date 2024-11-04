using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMetterChange : MonoBehaviour
{
    public Sprite noneSoundImage; // Array para armazenar as três versões
    public Sprite midSoundImage; // Array para armazenar as três versões
    public Sprite hightSoundImage; // Array para armazenar as três versões
    public PlayerSound playerSound; // Referência ao SpriteRenderer
    private Image spriteRenderer; // Referência ao SpriteRenderer

    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
        spriteRenderer.sprite = noneSoundImage;
    }

    void Update()
    {
        AtualizarImagem();
    }

    public void AtualizarImagem()
    {
        spriteRenderer.sprite = playerSound.playerNoise switch
        {
            PlayerSound.PlayerNoise.none => noneSoundImage,
            PlayerSound.PlayerNoise.mid => midSoundImage,
            _ => hightSoundImage,
        };
    }
}
