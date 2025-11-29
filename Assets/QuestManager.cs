using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public bool shellQuestComplete = false;
    public bool hatMemoryUnlocked = false;

    public bool bunnyMemoryUnlocked = false;
    public bool bookMemoryUnlocked = false;
    public int currentMemoryIndex = 0;

    public DayState currentDayState = DayState.Day;
    void Awake()
    {
        if (instance == null) instance = this;
    }
}

