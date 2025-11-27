using UnityEngine;

public class RoomMemoryDisplay : MonoBehaviour
{
    public GameObject hat;

    void Start()
    {
        if (PlayerPrefs.GetInt("hatCollected", 0) == 1)
            hat.SetActive(true);
    }
}
