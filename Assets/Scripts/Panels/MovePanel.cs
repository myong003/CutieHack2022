using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour
{
    [HideInInspector]
    public bool isControllable = true;
    [HideInInspector]
    public bool isTransitioning = false;
    bool moveUp = false;
    bool moveDown = false;
    public float maxspeed = 0.02f;

    public float topPos = 4, botPos = -4;
    Vector2[] positions = new Vector2[2]; // [0] top, [1] bottom
    // Start is called before the first frame update
    void Start()
    {
        positions[0] = new Vector2(transform.position.x, topPos);
        positions[1] = new Vector2(transform.position.x, botPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveUp){
            transform.position = Vector2.MoveTowards(transform.position, positions[0], maxspeed);
        }
        else if(moveDown){
            transform.position = Vector2.MoveTowards(transform.position, positions[1], maxspeed);
        }
        if(Vector2.Distance(transform.position, positions[0]) <= 0.001 || Vector2.Distance(transform.position, positions[1]) <= 0.001){
            isTransitioning = false;
        }
        if (!isControllable) return;

        if(Input.GetKeyDown(KeyCode.W) && !isTransitioning){
            isTransitioning = true;
            moveUp = true;
            moveDown = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isTransitioning){
            isTransitioning = true;
            moveUp = false;
            moveDown = true;
        }
    }
}