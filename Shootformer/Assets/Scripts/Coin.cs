using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    public int rotationSpeed = 20;

    public GameManager gm;

    public GameObject self;

    public AudioSource CoinGrab;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gm.coinsObtained = gm.coinsObtained + 1;
            CoinGrab.Play();
            Destroy(self);
        }
    }

    public void CoinShot()
    {
        gm.coinsObtained = gm.coinsObtained + 1;
        CoinGrab.Play();
        Destroy(self);
    }
}
