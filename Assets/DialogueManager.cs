using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage;

    public float typingSpeed = 0.3f;

    private void Awake()
    {
        instance = this;
    }

    public void ShowDialogue(string text, Sprite portrait = null)
    {
        StopAllCoroutines();
        dialoguePanel.SetActive(true);

        if (portrait != null)
            portraitImage.sprite = portrait;

        StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
