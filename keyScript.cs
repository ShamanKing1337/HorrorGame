using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public closedDoor doorScript;
    private bool check = false;
    public GameObject Key;
    // Start is called before the first frame update
    void Start()
    {
        doorScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (check == true))
        {
            doorScript.enabled = true;
            Destroy(Key);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            check = true;
            //doorScript.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            check = false;
            //doorScript.enabled = true;
        }
    }
}
