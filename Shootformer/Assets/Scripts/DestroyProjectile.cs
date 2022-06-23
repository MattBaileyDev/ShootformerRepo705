using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        StartCoroutine (DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        DestroyBullet2();
        
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(bullet);
    }

    IEnumerator DestroyBullet2()
    {
        yield return new WaitForSeconds(.01f);
        Destroy(bullet);
    }
}
