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

    bool playerOnCube = false;

    private Vector3 posLastFrame = Vector3.zero;

    public CharacterController CC;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CC = player.GetComponent<CharacterController>();
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

        if (playerOnCube == true)
        {
            //  player.transform.parent = Cube.transform;
            CC.Move(transform.position - posLastFrame);
        }

        posLastFrame = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnCube = true;

            //player.transform.parent = Cube.transform.;
            
        }

    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnCube = false;
            player.transform.parent = null;
            Cube.transform.parent = MovingCubes.transform;
        }
    }
}
