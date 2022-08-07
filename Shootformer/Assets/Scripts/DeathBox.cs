using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Debug;


public class DeathBox : MonoBehaviour
{
    public bool reachedCheckpoint1 = false;
    public bool reachedCheckpoint2 = false;
    public Transform Player;
    public Transform Checkpoint1;
    public Transform Checkpoint2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (reachedCheckpoint1 == false && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        if (reachedCheckpoint1 == true && other.gameObject.tag == "Player")
        {
            Player.transform.position = Checkpoint1.position;
            
        }
        else
        if(reachedCheckpoint2 == true && other.gameObject.tag == "Player")
        {
            Player.transform.position = Checkpoint2.position;
           

        }
    }
}
