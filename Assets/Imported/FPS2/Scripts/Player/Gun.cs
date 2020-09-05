using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Cam;
    public GameObject Player;
    // public Camera myCam;

    public bool IsUsingRayCasts;
    public bool IsUsingBullets;

    public Transform ShootingPoint;
    public GameObject Bullet;
    float timeBetweenShooting;
    public float startTimeBetweenShooting;
    public int damage = 25;
    public float range = 100f;
    public float spread = 0f;

    //public ParticleSystem ShootEffect;
    public void Shoot()
    {  
        if (IsUsingRayCasts)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                Vector3 colisionPoint = hit.point;
                Vector3 bulletVector = colisionPoint - Bullet.transform.position;

                GameObject bulletInstance = Instantiate(Bullet, Bullet.transform);
                // if (hit.collider.CompareTag("ExplosionBarrel"))
                //     hit.collider.GetComponent<ExplosionBarrel>().PushExplosion();

                Debug.Log(hit.collider.gameObject.name);
            }
        }

        if (IsUsingBullets)
        {
            //Calculate Direction and Spread
            //Quaternion Direction = Cam.transform.rotation + Quaternion.Euler(spread, spread, 0);

            // Instantiate(Bullet, ShootingPoint.position, Camera.main.transform.rotation);
        }
    }
    private void Update()
    {
        //Shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && timeBetweenShooting <= 0)
        {
            Shoot();
            timeBetweenShooting = startTimeBetweenShooting;
        }
        else
        {
            timeBetweenShooting -= Time.deltaTime;
        }
    }
}
