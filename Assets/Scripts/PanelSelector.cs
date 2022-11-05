using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSelector : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Alpha1) )
        {
            panel1.GetComponent<Panel>().enabled = true;
            panel2.GetComponent<Panel>().enabled = false;
            panel3.GetComponent<Panel>().enabled = false;
            Debug.Log("enable solar panel 1");
        }
        if ( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            panel2.GetComponent<Panel>().enabled = true;
            panel1.GetComponent<Panel>().enabled = false;
            panel3.GetComponent<Panel>().enabled = false;
            Debug.Log("enable solar panel 2");
        }
        if ( Input.GetKeyDown(KeyCode.Alpha3) )
        {
            panel3.GetComponent<Panel>().enabled = true;
            panel1.GetComponent<Panel>().enabled = false;
            panel2.GetComponent<Panel>().enabled = false;
            Debug.Log("enable solar panel 3");
        }
    }
}
