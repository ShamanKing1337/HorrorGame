using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedDoor : MonoBehaviour
{
    public GameObject Scream;
    private bool enter = false;

    private bool isOpened = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (enter == true) && (isOpened == false))
        {
            Scream.GetComponent<Animator>().SetTrigger("open");
            isOpened = true;
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && (enter == true) && (isOpened == true))
        {
            Scream.GetComponent<Animator>().SetTrigger("close");
            isOpened = false;
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
