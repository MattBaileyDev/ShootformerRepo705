using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCube : MonoBehaviour
{
    public Transform lerpNode1;
    public Transform lerpNode2;

    public float lerpSpeed = 1f;

    public float journeyLength = 1;
    private float startTime;

    public bool looping = false;

    public GameObject player;

    public GameObject colliderbox;

    public GameObject Cube;

    public GameObject MovingCubes;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       if (looping == false)
        {
            float distCovered = (Time.time - startTime) * lerpSpeed;
            transform.position = Vector3.Lerp(lerpNode1.position, lerpNode2.position, distCovered / journeyLength);

        }

       if (looping == true)
        {
            float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength / lerpSpeed);
            transform.position = Vector3.Lerp(lerpNode1.position, lerpNode2.position, distCovered / journeyLength);

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent = colliderbox.transform;
            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Cube.transform.parent = player.transform;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent = null;
            Cube.transform.parent = MovingCubes.transform;
        }
    }
}
