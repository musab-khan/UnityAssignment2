using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public bool canSpawn = true; // 1

    public GameObject zombiePrefab; // 2
    public List<Transform> zombieSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns; // 4

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnZombie ()
    {
        Vector3 randomPos = zombieSpawnPositions[Random.Range(0, zombieSpawnPositions.Count)].position;
        GameObject zombie = Instantiate(zombiePrefab, randomPos, Quaternion.identity);

    }

    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnZombie(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }
}
