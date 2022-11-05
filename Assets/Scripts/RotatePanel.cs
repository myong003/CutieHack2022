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
        if(Input.GetKey(KeyCode.A) && (transform.rotation.eulerAngles.z +180f) % 360f - 180f < 45){
            transform.RotateAround(transform.position, Vector3.forward, rotateSpeed);
        }
        else if(Input.GetKey(KeyCode.D) && (transform.rotation.eulerAngles.z +180f) % 360f - 180f > -45){
            transform.RotateAround(transform.position, Vector3.forward, -rotateSpeed);
        }
    }
}
