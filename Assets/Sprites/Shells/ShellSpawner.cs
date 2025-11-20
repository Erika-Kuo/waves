using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public GameObject[] shellPrefabs; 
    public int numberOfShells = 10;
    public Vector2 minPos;
    public Vector2 maxPos;

    void Start()
    {
        for (int i = 0; i < numberOfShells; i++)
        {
            Vector2 spawnPos = new Vector2(
                Random.Range(minPos.x, maxPos.x),
                Random.Range(minPos.y, maxPos.y)
            );

            Instantiate(shellPrefabs[Random.Range(0, shellPrefabs.Length)], spawnPos, Quaternion.identity);
        }
    }
}
