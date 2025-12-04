using UnityEngine;

public class MemoryUIManager : MonoBehaviour
{
    public static MemoryUIManager instance;

    public GameObject[] allMemoryImages; // hat, bunny, book

    void Awake()
    {
        instance = this;
    }

    public static void HideAllMemoryImages()
    {
        if (instance == null || instance.allMemoryImages == null) return;

        foreach (GameObject img in instance.allMemoryImages)
        {
            img.SetActive(false);
        }
    }
}
