using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chasing : MonoBehaviour
{

    private NavMeshAgent NashAgent;
    public Transform Target;
    public Transform Miner;
    // Start is called before the first frame update
    void Awake()
    {
        NashAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Vector3.Distance(Miner.position, Target.position) <= 20)
        {
            Vector3 targetDir = Target.position - Miner.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < 90.0F)
            {
                NashAgent.SetDestination(Target.position);
            }
        }
    }
}
