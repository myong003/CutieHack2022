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

    private float currTime;

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
        currTime = 0;
        Application.targetFrameRate = 60;


    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= endTime) {
            EndLevel();
        }
    }

    public void EndLevel() {
        Debug.Log("Day ended");
        SceneManager.LoadScene("LevelSelection");
    }
}
