using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
//using UnityEngine.Debug;


public class DeathBox : MonoBehaviour
{
    public bool reachedCheckpoint1 = false;
    public bool reachedCheckpoint2 = false;
    public GameObject Player;
    public GameObject Checkpoint1;
    public GameObject Checkpoint2;
    public PlayerMovement1 pm;
    
    
    
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
        if (reachedCheckpoint1 == true && reachedCheckpoint2 == false && other.gameObject.tag == "Player")
        {

            pm.enabled = false;
            Player.transform.position = Checkpoint1.transform.position;
            StartCoroutine("EnablePM");
            Debug.Log("moved player");
        }
        else
        if(reachedCheckpoint2 == true && other.gameObject.tag == "Player")
        {
            pm.enabled = false;
            Player.transform.position = Checkpoint2.transform.position;
            StartCoroutine("EnablePM");

        }
    }

    IEnumerator EnablePM()
    {
        yield return new WaitForSeconds(1);
        pm.enabled = true;
    }

   
}
