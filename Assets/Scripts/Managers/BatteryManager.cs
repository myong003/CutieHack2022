using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    public Transform batteryStart;
    public GameObject batteryNode;
    public GameObject sun;
    public TextMeshProUGUI batteryPercentText;
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

        // Maximum possible battery = 150% for buffer room
        // Since CheckPanels is called every frame, for endTime seconds, each increase must add up to max battery
        // Divide by 3 for each solar panel
        float totalSamples = GameManager.Instance.endTime * 60;
        batteryIncrease = Mathf.Abs(150 / totalSamples / solarPanels.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(batteryPercent);
        CheckPanels();
    }

    public void CheckPanels() {
        Vector3 sunPos = sun.transform.position;

        foreach (GameObject panel in solarPanels) {
            if (panel.GetComponent<MovePanel>().isBlocked) {
                Debug.Log("Panel " + panel.name + "is blocked");
                continue;
            }

            Vector3 panelPos = panel.transform.position;
            float panelRotation = (panel.transform.rotation.eulerAngles.z +180f) % 360f - 180f;

            // Calculate angle between sun and panel
            float deltaX = sunPos.x - panelPos.x;
            float deltaY = sunPos.y - panelPos.y;
            float angle = Mathf.Atan(-deltaX / deltaY) * 180f / Mathf.PI;

            // Check to see if angle matches the rotation of the panel
            float angleDifference = Mathf.Abs(angle - panelRotation);
            
            // If the difference is smaller than a perfect, increase points fully
            if (angleDifference < perfectScoreRange) {
                IncreaseBattery(batteryIncrease);
            }
            else if (angleDifference < goodScoreRange) {
                IncreaseBattery(batteryIncrease / 2);
            }
        }
    }

    public void IncreaseBattery(float batteryIncrease) {
        // Only increment if battery isn't full, doesn't increment past 100
        if (batteryPercent < 100) {
            batteryPercent += batteryIncrease;
            int nextLevel = (int) (batteryPercent / 10);

            // Check to see if batteryPerecent goes to next interval (10)
            if (nextLevel > currLevel) {
                // Add a new battery node to the meter
                Vector3 batteryPos = batteryStart.transform.position + new Vector3(0, batteryHeightDifference * currLevel, 0);
                Instantiate(batteryNode, batteryPos, Quaternion.identity);
            }

            // Update the current battery
            currLevel = nextLevel;
        }

        batteryPercentText.text = (int) batteryPercent + "%";
    }
}
