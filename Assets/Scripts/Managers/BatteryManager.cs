using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryManager : MonoBehaviour
{
    public Transform batteryStart;
    public GameObject batteryNode;
    public GameObject sun;
    public List<GameObject> solarPanels;
    public float batteryHeightDifference;
    public float perfectScoreRange;
    public float goodScoreRange;


    private int currLevel;
    private float batteryPercent;
    private float batteryIncrease;

    // Start is called before the first frame update
    void Start()
    {
        batteryPercent = 0;
        currLevel = 0;
        float totalSamples = GameManager.Instance.endTime * Application.targetFrameRate;
        batteryIncrease = 150 / totalSamples / 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(batteryPercent);
        CheckPanels();
    }

    public void CheckPanels() {
        // float sunRotation = (sun.transform.rotation.eulerAngles.z + 180f - 37.5f) % 360f - 180f ;
        Vector3 sunPos = sun.transform.position;

        foreach (GameObject panel in solarPanels) {
            Vector3 panelPos = panel.transform.position;
            float deltaX = sunPos.x - panelPos.x;
            float deltaY = sunPos.y - panelPos.y;
            float angle = Mathf.Atan(-deltaX / deltaY) * 180f / Mathf.PI;

            float panelRotation = (panel.transform.rotation.eulerAngles.z +180f) % 360f - 180f;
            float angleDifference = Mathf.Abs(angle - panelRotation);
            
            if (angleDifference < perfectScoreRange) {
                IncreaseBattery(batteryIncrease);
            }
            else if (angleDifference < goodScoreRange) {
                IncreaseBattery(batteryIncrease / 2);
            }
        }
    }

    public void IncreaseBattery(float batteryIncrease) {
        if (batteryPercent < 100) {
            batteryPercent += batteryIncrease;
            int nextLevel = (int) (batteryPercent / 10);

            if (nextLevel > currLevel) {
                Vector3 batteryPos = batteryStart.transform.position + new Vector3(0, batteryHeightDifference * currLevel, 0);
                Instantiate(batteryNode, batteryPos, Quaternion.identity);
            }

            currLevel = nextLevel;
        }
    }
}
