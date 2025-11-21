using UnityEngine;

public class Mound : MonoBehaviour
{
    public int requiredShells = 5;
    public GameObject homeDoor;  // drag your room door trigger here

    private bool playerNearby = false;
    private bool cutscenePlayed = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            if (cutscenePlayed) return; // prevent spamming

            if (ShellCounter.instance.shellCount >= requiredShells)
            {
                StartCoroutine(PlaceShellsCutscene());
            }
            else
            {
                DialogueManager.instance.ShowDialogue("I need more shells...");
            }
        }
    }

    private System.Collections.IEnumerator PlaceShellsCutscene()
    {
        cutscenePlayed = true;

        DialogueManager.instance.ShowDialogue("I should place the shells...");

        yield return new WaitForSeconds(2);

        DialogueManager.instance.ShowDialogue("The mound accepts the offering.");

        yield return new WaitForSeconds(2);

        DialogueManager.instance.ShowDialogue("I should go home now.");

        // Reset shell count (optional)
        ShellCounter.instance.shellCount = 0;
        ShellCounter.instance.UpdateText();

        // Unlock door so Marnie can return home
        if (homeDoor != null)
            homeDoor.SetActive(true);

        yield return new WaitForSeconds(2);

        DialogueManager.instance.HideDialogue();
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
