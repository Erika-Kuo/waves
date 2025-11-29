using UnityEngine;

public class RoomMemoryDisplay : MonoBehaviour
{
    public GameObject hatInRoom;
    public GameObject bunnyInRoom;
    public GameObject bookInRoom;

    void Start()
    {
        hatInRoom.SetActive(QuestManager.instance.hatMemoryUnlocked);
        bunnyInRoom.SetActive(QuestManager.instance.bunnyMemoryUnlocked);
        bookInRoom.SetActive(QuestManager.instance.bookMemoryUnlocked);
    }
}
