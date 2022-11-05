using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public Transform rotationPoint;

    private float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = 100 / (GameManager.Instance.endTime * 60);
    }

    // Update is called once per frame
    void Update()
    {
        MoveSun();
    }

    public void MoveSun() {

        this.gameObject.transform.RotateAround(rotationPoint.position, Vector3.forward, -rotationAngle);
    }
}
