using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movememt : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController controller;
    public float gravity = -9.81f;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;
    bool prevGrounded;

    private AudioSource m_MyAudioSource;
    public AudioClip[] m_FootstepSounds;
    public AudioClip m_Jump;
    public AudioClip m_Land;

    public Transform Mine;
    private int tmp = 0;
    private Vector3 pos;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = Mine.position;
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (prevGrounded == false && isGrounded == true)
        {
            m_MyAudioSource.clip = m_Land;
            m_MyAudioSource.PlayOneShot(m_MyAudioSource.clip);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        //{
         //   speed = 30f;
          //  CheckStep();
       // } else
       // {
         //   speed = 12f;
       // }


            if ((x != 0) || (z != 0))
        {
            CheckStep();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            m_MyAudioSource.clip = m_Jump;
            m_MyAudioSource.PlayOneShot(m_MyAudioSource.clip);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        prevGrounded = isGrounded;
    }

    void CheckStep()
    {
        if ((tmp % 30) == 0)
        {
            if (pos != Mine.position)
            {
                StepSound();
            }
            tmp = 0;
        }
        tmp++;
        pos = Mine.position;
    }

    void StepSound()
    {
        if (!isGrounded)
        {
            return;
        }

        int n = Random.Range(1, m_FootstepSounds.Length);
        m_MyAudioSource.clip = m_FootstepSounds[n];
        m_MyAudioSource.PlayOneShot(m_MyAudioSource.clip);
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_MyAudioSource.clip;

    }
}
