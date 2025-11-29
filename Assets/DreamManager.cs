using UnityEngine;

public class DreamManager : MonoBehaviour
{
    public GameObject hatMemory;
    public GameObject bunnyMemory;

    void Start()
    {
        hatMemory.SetActive(false);
        bunnyMemory.SetActive(false);

        if (QuestManager.instance.shellQuestComplete && !QuestManager.instance.hatMemoryUnlocked)
            hatMemory.SetActive(true);

        if (QuestManager.instance.hatMemoryUnlocked && !QuestManager.instance.bunnyMemoryUnlocked)
            bunnyMemory.SetActive(true);
    }
}

