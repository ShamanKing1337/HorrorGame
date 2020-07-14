using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Miner;
    public Transform Enemy;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Miner.position, Enemy.position) <= 2)
        {
            SceneManager.LoadScene(0);
        }
    }
}
