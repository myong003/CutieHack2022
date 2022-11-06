using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingText : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public string text;
    public float moveSpeed;

    private float moveTimer;
    private int currCharIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 0;
        moveSpeed = 1 / moveSpeed;
        tmpro.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (currCharIndex < text.Length) {
            if (moveTimer > moveSpeed) {
                tmpro.text += text[currCharIndex];
                currCharIndex++;
                moveTimer = 0;
            }
            moveTimer += Time.deltaTime;
        }
    }
}
