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
