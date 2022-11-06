using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public List<CloudSpawner> spawners;
    public float spawnDelay;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > spawnDelay) {
            int randIndex = Random.Range(0, spawners.Count);
            spawners[randIndex].SpawnCloud();
            spawnTimer = 0;
        }
        spawnTimer += Time.deltaTime;
    }
}
