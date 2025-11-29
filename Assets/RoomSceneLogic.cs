using UnityEngine;

public class RoomSceneLogic : MonoBehaviour
{
    public GameObject bedtimeBedTrigger;
    public GameObject morningDoorTrigger;

    void Start()
    {
        if (QuestManager.instance.currentDayState == DayState.Day)
        {
            DialogueManager.instance.ShowDialogue("A new day… I should go to the beach.");

            bedtimeBedTrigger.SetActive(false);
            morningDoorTrigger.SetActive(true);
        }
        else
        {
            DialogueManager.instance.ShowDialogue("I should get some sleep…");

            bedtimeBedTrigger.SetActive(true);
            morningDoorTrigger.SetActive(false);
        }
    }
}
