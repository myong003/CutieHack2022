using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    public BatteryManager batteryManager;
    public float endTime;
    GameObject Sky;

    private float currTime, skyRotateAngle;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Sky = GameObject.Find("DaynightV1-1.png");
        currTime = 0;
        Application.targetFrameRate = 60;
        skyRotateAngle = (100 / endTime) / 60; //180 - 80 degrees per frame so divide by 60

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        Sky.transform.RotateAround(Sky.transform.position, Vector3.forward, -skyRotateAngle);
        if (currTime >= endTime) {
            EndLevel();
        }
    }

    public void EndLevel() {
        Debug.Log("Day ended");
        SceneManager.LoadScene("LevelSelection");
    }
}
