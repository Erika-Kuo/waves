using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemoryInteract : MonoBehaviour
{
    public int memoryIndex;                // 0 = hat, 1 = bunny, 2 = book
    public GameObject memoryImageUI;       // The UI GameObject for THIS memory
    public Sprite memorySprite;            // Sprite for THIS memory
    public GameObject[] cutsceneImages;    // Images for THIS cutscene only
    public string[] dialogueLines;
    public Image memoryImageComponent;

    private bool playerNearby = false;
    private bool finished = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q) && !finished)
        {
            finished = true;
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        DreamMarnieMovement.instance.locked = true;

        // 🔥 IMPORTANT: hide ALL memory images first
        MemoryUIManager.HideAllMemoryImages();

        // 🔥 Now enable ONLY this one
        memoryImageUI.SetActive(true);
        memoryImageComponent.sprite = memorySprite;

        yield return null; 
        // Hide all cutscene images before starting
        foreach (GameObject img in cutsceneImages)
            img.SetActive(false);

        // Dialogue lines
        foreach (string line in dialogueLines)
        {
            memoryImageUI.SetActive(true);
            DialogueManager.instance.ShowDialogue(line);
            yield return new WaitForSeconds(3);
        }

        // Cutscene images
        foreach (GameObject img in cutsceneImages)
        {
            img.SetActive(true);
            yield return new WaitForSeconds(2);
            img.SetActive(false);
        }

        // Save memory
        if (memoryIndex == 0)
            QuestManager.instance.hatMemoryUnlocked = true;
        else if (memoryIndex == 1)
            QuestManager.instance.bunnyMemoryUnlocked = true;
        else if (memoryIndex == 2)
            QuestManager.instance.bookMemoryUnlocked = true;

        QuestManager.instance.memoryUnlocked[memoryIndex] = true;
        QuestManager.instance.currentMemoryIndex++;

        // Turn off our UI
        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();
        MemoryUIManager.HideAllMemoryImages();
    
        DreamMarnieMovement.instance.locked = false;
        QuestManager.instance.currentDayState = QuestManager.DayState.Day;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = false;
    }
}
