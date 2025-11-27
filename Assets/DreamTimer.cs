using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DreamTimer : MonoBehaviour
{
    public float dreamDuration = 60f;
    public TextMeshProUGUI timerText;

    private float timeLeft;

    void Start()
    {
        timeLeft = dreamDuration;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            EndDream();
        }
    }

    void EndDream()
    {
        // Fade out + return to home scene
        SceneManager.LoadScene("HomeScene");
    }
}
