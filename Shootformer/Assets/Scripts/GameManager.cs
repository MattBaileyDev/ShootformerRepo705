using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject PlayerCamera;

    public bool isFirstPerson = false;

    public GameObject Player;

    public GameObject AestheticGun;

    public GameObject[] PerspectiveCubeArray;

    public CameraFollow camFollow;

    public int coinsObtained;

    public GameObject canvas;

    public Text coins;

    public CinemachineVirtualCamera Main;
    public CinemachineVirtualCamera PlayerCam;

    public GameObject Container;

    public bool isLevel2 = false;

    

    // Start is called before the first frame update
    void Start()
    {
        PerspectiveCubeArray = GameObject.FindGameObjectsWithTag("PerspectiveCube");
        coinsObtained = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Container.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "COINS - " + coinsObtained + "/3";

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFirstPerson = !isFirstPerson;
        }

        if (isFirstPerson == false)
        {
            
            canvas.transform.parent = MainCamera.transform;
            PlayerCam.Priority = 9;
            Main.Priority = 10;
            Camera.main.orthographic = true;
            Container.SetActive(false);
            //PlayerCamera.gameObject.SetActive(false);
            //MainCamera.gameObject.SetActive(true);
            AestheticGun.gameObject.SetActive(true);
            if (isLevel2 == false)
            {
                Vector3 position = Player.transform.position;
                position.z = 0;
                Player.transform.position = position;
            }
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);


            


        }
        else
        {
            
            
            canvas.transform.parent = PlayerCamera.transform;
            AestheticGun.gameObject.SetActive(false);
            Container.SetActive(true);
            PlayerCam.Priority = 10;
            Main.Priority = 9;
            Camera.main.orthographic = false;
            //PlayerCamera.gameObject.SetActive(true);
            ////camFollow.Follow();
            //MainCamera.gameObject.SetActive(false);

        }

        if (isFirstPerson == true)
        {
            foreach (GameObject go in PerspectiveCubeArray)
            {
                go.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in PerspectiveCubeArray)
            {
                go.SetActive(true);
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        isLevel2 = true;
    }
    
    
}
