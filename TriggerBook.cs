using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBook : MonoBehaviour
{
    public door doorScript;
    public UpPaper paperScript;
    public GameObject TextUp;
    public GameObject Paper;
   // public door doorScript;

    // Start is called before the first frame update
    void Start()
    {
        paperScript.enabled = false;
        doorScript.enabled = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            TextUp.SetActive(true);
            paperScript.enabled = true;
            doorScript.enabled = true;
            //doorScript.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Paper.SetActive(false);
            TextUp.SetActive(false);
            paperScript.enabled = false;
        }
    }
}
