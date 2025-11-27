using UnityEngine;

public class MemoryObject : MonoBehaviour
{
    public GameObject memoryImageUI;

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
        DreamMarnieMovement.instance.locked = false;

        memoryImageUI.SetActive(true);

        DialogueManager.instance.ShowDialogue("It's... it's my hat. Mama? Mama gave this to me. I remember now.");

        yield return new WaitForSeconds(5);

        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();

        DreamMarnieMovement.instance.locked = true;
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
