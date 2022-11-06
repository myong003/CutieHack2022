using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    public GameObject endScreenLose;
    public GameObject endScreenWin;
    public Image blackScreenLose;
    public Image blackScreenWin;
    public float fadeSpeed;

    public BatteryManager batteryManager;
    public float endTime;
    GameObject Sky;

    GameObject FogTileMap;

    private float currTime, skyRotateAngle, FogTileMapA;
    private bool gameEnded = false;

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
        if (currTime >= endTime && !gameEnded) {
            EndLevel();
        }
    }

    public void EndLevel() {
        Debug.Log("Day ended");
        if ( batteryManager.batteryPercent < 100 && !gameEnded)
        {
            // SceneManager.LoadScene("GameOverScreen");
            StartCoroutine("FadeToBlackLose");
        }
        else
        {
            // SceneManager.LoadScene("WinScreen"); 
            StartCoroutine("FadeToBlackWin");
        }
    }


    IEnumerator FadeToBlackLose() {
        gameEnded = true;
        while (blackScreenLose.color.a < 1f) {
            Color c = blackScreenLose.color;
            c.a += fadeSpeed;
            blackScreenLose.color = c;
            yield return null;
        }

        endScreenLose.SetActive(true);
    }
    
    IEnumerator FadeToBlackWin() {
        gameEnded = true;
        while (blackScreenWin.color.a < 1f) {
            Color c = blackScreenWin.color;
            c.a += fadeSpeed;
            blackScreenWin.color = c;
            yield return null;
        }

        endScreenWin.SetActive(true);
    }
}
