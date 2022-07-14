using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement1 : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3;

    Vector3 velocity;

    public GameManager gm;

    public Camera MainCamera;

    public AudioSource Jump;

    private Vector3 parentPosLastFrame;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (gameObject.transform.parent!=null)
        {

        }


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (gm.isFirstPerson == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }

        if (gm.isFirstPerson == false)
        {
            float z = Input.GetAxis("Horizontal");

            Vector3 move2d = transform.forward * z;

            controller.Move(move2d * speed * Time.deltaTime);
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Jump.Play();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

   
}
