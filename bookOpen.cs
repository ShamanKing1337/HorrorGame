using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookOpen : MonoBehaviour
{
    public bool enter = false;
    public GameObject image;

    public bool isOpened = false;

    public movememt movementScript;
    public mousescript mouse;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (enter == true) && (isOpened == false))
        {
            image.SetActive(true);
            isOpened = true;
            movementScript.enabled = false;
            mouse.enabled = false;
        } else if ((Input.GetKeyDown(KeyCode.E))  && (isOpened == true))
        {
            image.SetActive(false);
            isOpened = false;
            movementScript.enabled = true;
            mouse.enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
        }
    }
}
