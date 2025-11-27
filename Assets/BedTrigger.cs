using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour
{
    public string DreamScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (!QuestManager.instance.shellQuestComplete)
        {
            DialogueManager.instance.ShowDialogue("I should finish at the beach first.");
            return;
        }

        // Allowed to sleep
        SceneManager.LoadScene(DreamScene);
    }
}
