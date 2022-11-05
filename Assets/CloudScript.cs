using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float moveSpeed;
    public int direction;       // 1 for moving right, -1 for moving left

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);    
    }
}
