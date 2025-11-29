using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour
{
    public string DreamScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // Allowed to sleep
        SceneManager.LoadScene(DreamScene);
    }
}
public class SleepDialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueManager.instance.ShowDialogue("I feel sleepy... I should go to bed.");
    }
}
