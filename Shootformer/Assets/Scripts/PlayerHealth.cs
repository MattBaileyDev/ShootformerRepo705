using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float health = 10;
    public float grenadeDamage = 2;
    public GameObject hitgrenade;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("MainLevel");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grenade")
        {
            health -= grenadeDamage;
            hitgrenade = collision.gameObject;

            Destroy(hitgrenade);
            
        }

       


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && gm.isFirstPerson == false)
        {
            health = 0;
        }
    }
}
