using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public PlayerMovement1 pm;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter (Collider other)
    {
        pm.isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        pm.isGrounded = false;
    }
}
