using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoints : MonoBehaviour
{
    public DeathBox db;
    public GameObject Checkpoint1;
    public GameObject Checkpoint2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Collider>().name == "Checkpoint 1")
        {
            db.reachedCheckpoint1 = true;

        }
        else
        if (GetComponent<Collider>().name == "Checkpoint 2")
        {
            db.reachedCheckpoint2 = true;
        }
    }
}
