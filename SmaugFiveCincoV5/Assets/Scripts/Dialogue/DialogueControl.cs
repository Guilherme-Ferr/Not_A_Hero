using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; // janela do diálogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; // nome do NPC

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala

    // Variáveis de controle
    [HideInInspector] public bool isShowing; // Se a janela de diálogo está visível
    private int index; // índice da sentença
    private string[] sentences;

    private PlayerMovement playerd;

    // Utilize a tecla F para avançar o diálogo
    public KeyCode advanceKey = KeyCode.F;

    private float delayAfterDialogue = 1f; // Atraso em segundos após o término do diálogo
    private bool delayInProgress; // Verifica se o atraso está em andamento

    public static DialogueControl instance;

    // Awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        playerd = FindObjectOfType<PlayerMovement>();
    }

    // Pular para a próxima fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                StartCoroutine(DelayBeforeNextDialogue());
                playerd.isPaused = false;
            }
        }
    }

    // Chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            index = 0; // Iniciar do início quando um novo diálogo é iniciado
            StartCoroutine(TypeSentence());
            isShowing = true;
            playerd.isPaused = true;
        }
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Fechar a caixa de diálogo
    private void EndDialogue()
    {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        sentences = null;
        isShowing = false; // Importante definir isShowing como false quando o diálogo termina
    }

    // Adicionar atraso antes de permitir um novo diálogo
    private IEnumerator DelayBeforeNextDialogue()
    {
        delayInProgress = true;
        yield return new WaitForSeconds(delayAfterDialogue);
        delayInProgress = false;
        EndDialogue();
    }

    // Verifica se a tecla F foi pressionada para avançar o diálogo ou fechar o diálogo
    private void Update()
    {
        if (isShowing)
        {
            if (Input.GetKeyDown(advanceKey) && !delayInProgress)
            {
                NextSentence();
            }
        }
    }
}
