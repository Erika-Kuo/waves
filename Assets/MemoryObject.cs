using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MemoryObject : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        StartCoroutine(MemoryCutscene());
    }

    private IEnumerator MemoryCutscene()
    {
        DialogueManager.instance.ShowDialogue("I remember this...");
        yield return new WaitForSeconds(2);

        DialogueManager.instance.ShowDialogue("Mama used to put this on me...");
        yield return new WaitForSeconds(2);

        // Add item to room next morning
        PlayerPrefs.SetInt("hatCollected", 1);

        SceneManager.LoadScene(nextSceneName);
    }
}
