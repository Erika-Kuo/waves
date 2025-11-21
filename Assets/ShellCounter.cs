using UnityEngine;
using TMPro;

public class ShellCounter : MonoBehaviour
{
    public static ShellCounter instance;

    public int shellCount = 0;
    public TMP_Text counterText;

    void Awake()
    {
        instance = this;
    }

    public void AddShell()
    {
        shellCount++;
        counterText.text = shellCount.ToString();
    }
}
