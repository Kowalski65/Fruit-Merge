using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public float spawnHeight = 5f;
    public float spawnCooldown = 3f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextSpawnTime)
        {
            SpawnFruit();
            nextSpawnTime = Time.time + spawnCooldown; 
        }
    }

    void SpawnFruit()
    {
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPos.y = spawnHeight;
        spawnPos.z = 0;

        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        Instantiate(fruitPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}
