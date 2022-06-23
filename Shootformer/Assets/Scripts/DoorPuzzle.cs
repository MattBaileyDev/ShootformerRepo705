using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public bool Target1Hit = false;
    public bool Target2Hit = false;
    public bool Target3Hit = false;
    public bool Target4Hit = false;
    public bool Target5Hit = false;

    public bool isTwoTarget;
    

    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTwoTarget == false && Target1Hit && Target2Hit && Target3Hit && Target4Hit && Target5Hit)
        {
            Destroy(Door);
        }

        if (isTwoTarget == true && Target1Hit && Target2Hit)
        {
            Destroy(Door);
        }

       
    }
}
