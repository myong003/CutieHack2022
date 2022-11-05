using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    public float spawnDelay;
    public int direction;


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
            spawnTimer = 0;
            SpawnCloud();
        }
        spawnTimer += Time.deltaTime;
    }

    public void SpawnCloud() {
        Vector3 currPos = this.transform.position;
        CloudScript tempCloud = Instantiate(cloud, currPos + new Vector3(0, Random.Range(-1, 1)), Quaternion.identity).GetComponent<CloudScript>();
        tempCloud.direction = this.direction;

        Destroy(tempCloud.gameObject, 10f);
    }
}
