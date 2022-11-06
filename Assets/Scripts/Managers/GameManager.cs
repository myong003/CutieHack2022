using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    public BatteryManager batteryManager;
    public float endTime;
    GameObject Sky;

    GameObject FogTileMap;

    private float currTime, skyRotateAngle, FogTileMapA;

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
        FogTileMap = GameObject.Find("FogTilemap");
        Sky = GameObject.Find("DaynightV1-1.png");
        currTime = 0;
        Application.targetFrameRate = 60;
        skyRotateAngle = (100 / endTime) / 60; //180 - 80 degrees per frame so divide by 60
        FogTileMapA = 1;

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        Sky.transform.RotateAround(Sky.transform.position, Vector3.forward, -skyRotateAngle);
        FogTileMapA += (140 / endTime) / 60;
        FogTileMap.GetComponent<Tilemap>().color = new Color(0.4716981f,0.4716981f,0.4716981f, FogTileMapA/255); //gray with increasing opacity
        if (currTime >= endTime) {
            EndLevel();
        }
    }

    public void EndLevel() {
        Debug.Log("Day ended");
        if ( batteryManager.batteryPercent < 100 )
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        else
        {
            SceneManager.LoadScene("WinScreen"); 
        }
    }
}
