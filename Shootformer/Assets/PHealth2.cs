using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EnemyAI;

public class PHealth2 : HealthManager
{

    public float health = 100f;
    public override void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart = null, GameObject origin = null)
    {
        health -= damage;

        if (health < 0)
        {
            dead = true;
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
