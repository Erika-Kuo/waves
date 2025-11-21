using UnityEngine;

public class Mound : MonoBehaviour
{
    public int requiredShells = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ShellCounter.instance.shellCount >= requiredShells)
            {
                Debug.Log("You place the shells on the mound.");
                // trigger animation or progress the story
            }
            else
            {
                Debug.Log("I need more shells...");
            }
        }
    }
}
