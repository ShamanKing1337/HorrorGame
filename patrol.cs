using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class patrol : MonoBehaviour
{
    private NavMeshAgent NashAgent;
    public List<Transform> dots;
    public Transform Mine;
    public Transform first;
    private Vector3 pos;
    private int tmp = 0;
    public int size;

    // Start is called before the first frame update
    void Awake()
    {
        NashAgent = GetComponent<NavMeshAgent>();


    }
    void Start()
    {
        NashAgent.SetDestination(first.position);
        pos = Mine.position;
    }
    // Update is called once per frame
    void Update()
    {

        if ((tmp % 50) == 0) {
            for (int i = 0; i < size; i++)
            {
                if (Vector3.Distance(Mine.position, dots[i].position) < 1)
                {
                    int rnd = Random.Range(0, size);
                    NashAgent.SetDestination(dots[rnd].position);
                }
            }
            if (Vector3.Distance(Mine.position, pos) < 1) 
            {
                int rnd = Random.Range(0, size);
                NashAgent.SetDestination(dots[rnd].position);
            }
            tmp = 0;
            pos = Mine.position;
        }
        tmp++;


    }
}
