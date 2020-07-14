using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject Scream;
    private bool enter = false;
    public GameObject image;

    private bool isOpened = false;

    private int time;
    private bool check = false;
    public AudioClip sound;
    private AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = Scream.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (enter == true) && (isOpened == false) && (check == false))
        {
            Scream.GetComponent<Animator>().SetTrigger("open");
            isOpened = true;
            image.SetActive(true);
            m_MyAudioSource.clip = sound;
            m_MyAudioSource.PlayOneShot(m_MyAudioSource.clip);
            check = true;
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && (enter == true) && (isOpened == true))
        {
            Scream.GetComponent<Animator>().SetTrigger("close");
            isOpened = false;
        }
        if (check == true)
        {
            time++;
            if ((time % 200) == 0)
            {
                image.SetActive(false);
            }
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
