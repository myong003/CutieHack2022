using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePanel : MonoBehaviour
{
    public float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MovePanel>().isTransitioning || gameObject.GetComponent<MovePanel>().isDisable) return;
        if(Input.GetKey(KeyCode.A) && (transform.GetChild(1).rotation.eulerAngles.z +180f) % 360f - 180f < 45){
            transform.GetChild(1).RotateAround(transform.GetChild(1).position, Vector3.forward, rotateSpeed);
        }
        else if(Input.GetKey(KeyCode.D) && (transform.GetChild(1).rotation.eulerAngles.z +180f) % 360f - 180f > -45){
            transform.GetChild(1).RotateAround(transform.GetChild(1).position, Vector3.forward, -rotateSpeed);
        }   
    }
}
