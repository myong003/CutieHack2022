using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    public GameObject thunderCloud; 
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
        float thunderRandom = Random.Range(0, 5);
        Vector3 randomOffset = new Vector3(0, Random.Range(-0.5f, 0.5f), 0);

        Vector3 currPos = this.transform.position;
        if ( thunderRandom == 1 )
        {
            ThunderScript tempthunderCloud = Instantiate(thunderCloud, currPos + randomOffset, Quaternion.identity).GetComponent<ThunderScript>();
            tempthunderCloud.direction = this.direction;
            Destroy(tempthunderCloud.gameObject, 10f);
        }
        else 
        {
            CloudScript tempCloud = Instantiate(cloud, currPos + randomOffset, Quaternion.identity).GetComponent<CloudScript>();
            tempCloud.direction = this.direction;
            Destroy(tempCloud.gameObject, 10f);
        }
    }
}
