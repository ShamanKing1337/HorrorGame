using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject Scream;
    private bool Check;
    private int Time;
    private AudioSource m_MyAudioSource;
    public AudioClip Sound;
    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = Scream.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Check == true)
        {
            Time++;
            if(Time > 200)
            {
                Destroy(Scream);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Scream.GetComponent<Animator> ().SetTrigger ("scream");
            m_MyAudioSource.clip = Sound;
            m_MyAudioSource.PlayOneShot(m_MyAudioSource.clip);
            Check = true;
        }
    }
}
