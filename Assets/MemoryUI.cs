using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryUI : MonoBehaviour
{
    public static MemoryUI instance;

    public GameObject panel;
    public Image imageDisplay;
    public TMP_Text dialogueDisplay;

    void Awake()
    {
        instance = this;
        panel.SetActive(false);
    }

    public void Show(Sprite sprite, string dialogue)
    {
        panel.SetActive(true);
        imageDisplay.sprite = sprite;
        dialogueDisplay.text = dialogue;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
