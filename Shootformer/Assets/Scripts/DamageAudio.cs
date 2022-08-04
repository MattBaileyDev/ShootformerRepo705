using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class DamageAudio : MonoBehaviour
{
    public AudioSource Damage;
    public HealthManager hm;
    public bool hasGrunted;
    public float gruntTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hm.isTakingDamage && gruntTimer == 3 && hasGrunted == false)
        {
            Damage.Play();
            hasGrunted = true;

        }

        if (hasGrunted == true)
        {

            gruntTimer -= Time.deltaTime;

            if (gruntTimer <= 0)
            {
                gruntTimer = 3;
                hasGrunted = false;


            }
        }

    }
      

}
