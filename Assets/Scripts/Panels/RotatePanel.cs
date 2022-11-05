using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePanel : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            transform.RotateAround(transform.position, Vector3.right, rotateSpeed);
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            transform.RotateAround(transform.position, Vector3.right, rotateSpeed);
        }
    }
}
