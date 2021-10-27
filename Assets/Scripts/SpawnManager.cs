using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public Transform[] spawnPoints;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (Transform spawn in spawnPoints)
        {
            spawn.gameObject.SetActive(false);
        }
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
