using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    public GameObject Grenade;

    public Transform NadeShootPoint;

    public float nadeVelocity;

    public LineRenderer lineRenderer;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            lineRenderer.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            lineRenderer.enabled = false;

            if (gm.isFirstPerson)
            {
                ShootGrenade();
            }
        }
    }

    private void ShootGrenade()
    {
        GameObject grenade = Instantiate(Grenade, NadeShootPoint.position, NadeShootPoint.rotation);
        Grenade.GetComponent<Rigidbody>().velocity = NadeShootPoint.transform.up * nadeVelocity;
    }
}
