using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public bool shellQuestComplete = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }
}

