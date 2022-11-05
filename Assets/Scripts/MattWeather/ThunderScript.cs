using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    public float moveSpeed;
    public int direction;       // 1 for moving right, -1 for moving left

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    void start()
    {
        //panel1 = GameObject.FindWithTag("Panel");
        //panel2 = GameObject.FindWithTag("Panel2");
        //panel3 = GameObject.FindWithTag("Panel3");
    }
    
    IEnumerator waitDestroy()
    {
        panel1.GetComponent<MovePanel>().isDisable = true;
        yield return new WaitForSeconds(3);
        panel1.GetComponent<MovePanel>().isDisable = false;
    }

    IEnumerator waitDestroy2()
    {
        panel2.GetComponent<MovePanel>().isDisable = true;
        yield return new WaitForSeconds(3);
        panel2.GetComponent<MovePanel>().isDisable = false;
    }

    IEnumerator waitDestroy3()
    {
        panel3.GetComponent<MovePanel>().isDisable = true;
        yield return new WaitForSeconds(3);
        panel3.GetComponent<MovePanel>().isDisable = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);    
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
       if ( collider.gameObject.tag == "Panel" )
       {
           StartCoroutine("waitDestroy");
           Debug.Log("panel1 disabled");
       }
       if ( collider.gameObject.tag == "Panel2" )
       {    
           StartCoroutine("waitDestroy2");
           Debug.Log("panel2 disabled");
       }
       if ( collider.gameObject.tag == "Panel3" )
       {
           StartCoroutine("waitDestroy3");
           Debug.Log("panel3 disabled");
       }
    }
}
