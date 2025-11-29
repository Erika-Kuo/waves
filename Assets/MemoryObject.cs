using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryObject : MonoBehaviour
{
    public GameObject memoryImageUI;
    public enum MemoryType { Hat, Bunny }
    public MemoryType memoryType;

    private bool playerNearby = false;
    private bool seenMemory = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q) && !seenMemory)
        {
            seenMemory = true;
            StartCoroutine(PlayMemoryCutscene());
        }
    }

    private System.Collections.IEnumerator PlayMemoryCutscene()
    {
        // stop movement
        DreamMarnieMovement.instance.locked = true;

        memoryImageUI.SetActive(true);

        if (memoryType == MemoryType.Hat)
            DialogueManager.instance.ShowDialogue("It's my hat... Mama gave this to me.");
        else
            DialogueManager.instance.ShowDialogue("My bunny... I remember holding this at night.");

        yield return new WaitForSeconds(5);

        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();
        DreamMarnieMovement.instance.locked = false;
        // unlock correct memory
        if (memoryType == MemoryType.Hat)
            QuestManager.instance.hatMemoryUnlocked = true;
        else
            QuestManager.instance.bunnyMemoryUnlocked = true;

        // THIS STOPS DreamTimer from running its normal ending
        //QuestManager.instance.dreamEndedNormally = false;

        // Return to home scene
        SceneManager.LoadScene("HomeScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNearby = false;
    }
}
