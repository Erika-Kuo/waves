using UnityEngine;
using UnityEngine.UI;

public class CutsceneImageController : MonoBehaviour
{
    public static CutsceneImageController instance;

    public Image cutsceneImage; // reference to the UI image

    private void Awake()
    {
        instance = this;
        cutsceneImage.color = new Color(1, 1, 1, 0); // start hidden
    }

    public void ShowImage(Sprite sprite)
    {
        cutsceneImage.sprite = sprite;
        cutsceneImage.color = new Color(1, 1, 1, 1); // fully visible
    }

    public void HideImage()
    {
        cutsceneImage.color = new Color(1, 1, 1, 0); // fully hidden
    }
}
