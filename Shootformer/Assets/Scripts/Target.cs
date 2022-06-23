using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public Material green;

    public GameObject targetBackground;

    public int TargetNumber;

    public DoorPuzzle doorPuzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetHit()
    {
        targetBackground.GetComponent<MeshRenderer>().material = green;

        if (TargetNumber == 1 )
        {
            doorPuzzle.Target1Hit = true;
        }

        if (TargetNumber == 2)
        {
            doorPuzzle.Target2Hit = true;
        }

        if (TargetNumber == 3)
        {
            doorPuzzle.Target3Hit = true;
        }

        if (TargetNumber == 4)
        {
            doorPuzzle.Target4Hit = true;
        }

        if (TargetNumber == 5)
        {
            doorPuzzle.Target5Hit = true;
        }
    }
}
