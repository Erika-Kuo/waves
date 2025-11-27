using UnityEngine;

public class NewDayDialogue : MonoBehaviour
{
    void Start()
    {
        DialogueManager.instance.ShowDialogue("A new day... I should go to the beach.");
    }
}