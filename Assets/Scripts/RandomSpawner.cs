using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] myCollectables;

    public float spawnDelay = 0.005f;
    private float nextSpawnTime = 0f;

    public float[] laneYPositions;

    public float minX = -8f;
    public float maxX = 8f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCollectable();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnCollectable()
    {
        int randomIndex = Random.Range(0, myCollectables.Length);

        float laneY = laneYPositions[Random.Range(0, laneYPositions.Length)];

        float xPos = Random.Range(minX, maxX);

        Vector2 spawnPos = new Vector2(xPos, laneY);

        
        GameObject spawned = Instantiate(myCollectables[randomIndex], spawnPos, Quaternion.identity);

        Destroy(spawned, spawnDelay);
    }

}
