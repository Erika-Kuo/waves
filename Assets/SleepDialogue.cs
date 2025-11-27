using UnityEngine;

public class SleepDialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueManager.instance.ShowDialogue("I feel sleepy... I should go to bed.");
    }
}
