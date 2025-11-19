using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnDelay = 0.3f;
    public GameObject car;
    public Transform[] spawnPoints;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject spawnedCar = Instantiate(car, spawnPoint.position, spawnPoint.rotation);

        StartCoroutine(RemoveCar(spawnedCar));
    }

    IEnumerator RemoveCar(GameObject spawnedCar)
    {
        yield return new WaitForSeconds(5);
        Destroy(spawnedCar);
    }
}
