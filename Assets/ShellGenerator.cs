using UnityEngine;

public class ShellGenerator : MonoBehaviour
{
    [Header("Shell Settings")]
    public GameObject[] shellPrefabs;   // Multiple shell types
    public int shellCount = 10;

    [Header("Spawn Area")]
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        SpawnShells();
    }

    void SpawnShells()
    {
        for (int i = 0; i < shellCount; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y)
            );

            // Pick a random shell type
            GameObject shell = shellPrefabs[Random.Range(0, shellPrefabs.Length)];

            Instantiate(shell, randomPos, Quaternion.identity);
        }
    }
}
