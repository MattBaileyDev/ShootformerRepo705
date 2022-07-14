using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow1 : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    public GameManager gm;

    public GameObject gun1;

    public GameObject gun2;

    public CinemachineVirtualCamera CineCam;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //Follow();

        if (gm.isFirstPerson == false && Input.GetKey(KeyCode.A))
        {
            var ThirdPersonFollow = CineCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if (ThirdPersonFollow.CameraSide > 0)
            {
                ThirdPersonFollow.CameraSide = ThirdPersonFollow.CameraSide -= 0.1f;
            }
            //offset.Set(-5, 0, -20);
            gun1.SetActive(false);
            gun2.SetActive(true);       
        }

        if (gm.isFirstPerson == false && Input.GetKey(KeyCode.D))
        {
            var ThirdPersonFollow = CineCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if (ThirdPersonFollow.CameraSide < 1)
            {
                ThirdPersonFollow.CameraSide = ThirdPersonFollow.CameraSide += 0.1f;
            }
            //offset.Set(5, 0, -20);
            gun1.SetActive(true);
            gun2.SetActive(false);
        }

    }

    //public void Follow()
    //{
    //    Vector3 targetPosition = player.position + offset;
    //    Vector3 smoothPosition = Vector3.Lerp(player.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
    //    //transform.position = smoothPosition;
    //}
}
