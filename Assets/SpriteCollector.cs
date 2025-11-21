using UnityEngine;
using UnityEngine.UI;

public class ShellCollector : MonoBehaviour
{
    public int shellCount = 0;
    public Text shellCounterText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Shell"))
            {
                Destroy(hit.gameObject);
                shellCount++;
                shellCounterText.text = shellCount.ToString();
                return;
            }
        }
    }
}
