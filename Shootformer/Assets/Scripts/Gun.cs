using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using EnemyAI;

public class Gun : MonoBehaviour
{

    public Camera FPSCamera;
    public GameObject Bullet;
    public GameObject Grenade;
    public GameObject Shootpoint;
    public Transform NadeShootPoint;
    public Transform ShootPoint;
    public AudioSource ShotSound;
    public AudioSource HitSound;

    public float nadeVelocity = 10f;
    public float bulletForceForward = 100f;
    public float bulletForceUp;

    public LineRenderer lineRenderer;

    public GameManager gm;

    public string RaycastReturn;

    public EnemyAI1 enemy;

    public EnemyHealth enemyHealth;

    public ParticleSystem muzzleflash;

    //public float pointRotationSpeed = 1;

    //public float mouseSensitivity = 100f;

    public TrailRenderer BulletTrail;

    public Target target;

    public Coin coin;

    public int bulletDamage = 10;
    

   // float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gm.isFirstPerson)
        {
            Shoot();
            
        }

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

        //if (gm.isFirstPerson == false)
        //{
        //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        //    xRotation -= mouseY;
        //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //    NadeShootPoint.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //    NadeShootPoint.Rotate(Vector3.up * mouseX);
        //}
    }

    private void Shoot()
    {
        //GameObject bullet = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        //Grenade.GetComponent<Rigidbody>().velocity = ShootPoint.transform.forward * bulletVelocity;
        muzzleflash.Play();
        ShotSound.Play();

        Ray ray = FPSCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            

            TrailRenderer trail = Instantiate(BulletTrail, ShootPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            targetPoint = hit.point;
            if (hit.collider != null)
            {
                hit.collider.SendMessageUpwards("HitCallback", new HealthManager.DamageInfo(hit.point, ShootPoint.forward, bulletDamage, hit.collider), SendMessageOptions.DontRequireReceiver);

                RaycastReturn = hit.collider.gameObject.name;
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    //enemy = hit.collider.gameObject.GetComponent<EnemyAI1>();
                    //enemy.TakeDamage();
                    //enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
                    ////enemyHealth.TakeDamage();
                    
                    HitSound.Play();
                }
                Debug.Log(RaycastReturn);


                if (hit.collider.gameObject.tag == "Target")
                {
                    Debug.Log("Hit Target");
                    target = hit.collider.gameObject.GetComponent<Target>();
                    target.TargetHit();
                    target = null;
                    HitSound.Play();
                }

                if(hit.collider.gameObject.tag == "Coin")
                {
                    Debug.Log("Hit Coin");
                    coin = hit.collider.gameObject.GetComponent<Coin>();
                    coin.CoinShot();
                    coin = null;
                }
            }



            
        }
        else
        {
            targetPoint = ray.GetPoint(75);
            
        }

        

        //GameObject bullet = Instantiate(Bullet, Shootpoint.transform.position, Shootpoint.transform.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = (targetPoint - transform.position).normalized * bulletForceForward;




    }

    private void ShootGrenade()
    {
        GameObject grenade = Instantiate(Grenade, NadeShootPoint.position, NadeShootPoint.rotation);
        Grenade.GetComponent<Rigidbody>().velocity = NadeShootPoint.transform.up * nadeVelocity;
    }

    IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
          
    
          Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
          time += Time.deltaTime / Trail.time;
            

          
                
            
            
            

            yield return null;
        }
        Trail.transform.position = hit.point;

        Destroy(Trail.gameObject, Trail.time);
    }
}
