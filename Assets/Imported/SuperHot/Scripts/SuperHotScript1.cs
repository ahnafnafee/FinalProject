using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SuperHotScript1 : MonoBehaviour
{

    public static SuperHotScript1 instance;

    public Camera myCam;
    
    public float charge;
    public bool canShoot = true;
    public bool action;
    public GameObject bullet;
    public Transform bulletSpawner;

    [Header("Weapon")]
    public WeaponScript weapon;
    public Transform weaponHolder;
    public LayerMask weaponLayer;


    [Space]
    [Header("UI")]
    public Image indicator;

    [Space]
    [Header("Prefabs")]
    public GameObject hitParticlePrefab;
    public GameObject bulletPrefab;

    public void Start()
    {
        GlobalVar.GunName = "Gun";
    }

    private void Awake()
    {
        instance = this;
        if (weaponHolder.GetComponentInChildren<WeaponScript>() != null)
            weapon = weaponHolder.GetComponentInChildren<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        if (!GlobalVar.IsPaused || !GlobalVar.AltInterfaceOpen)
        {
            if (canShoot && GlobalVar.GunName == "Gun")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StopCoroutine(ActionE(.03f));
                    StartCoroutine(ActionE(.03f));
                    if (weapon != null)
                        weapon.Shoot(SpawnPos(), myCam.transform.rotation, false);
                }
            }

            RaycastHit hit;
            if(Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit,10, weaponLayer))
            {
                if (Input.GetMouseButtonDown(0) && weapon == null)
                {
                    hit.transform.GetComponent<WeaponScript>().Pickup();
                }
            }
        }

    }

    IEnumerator ActionE(float time)
    {
        action = true;
        yield return new WaitForSecondsRealtime(.06f);
        action = false;
    }
    
    public void ReloadUI(float time)
    {
        indicator.transform.DORotate(new Vector3(0, 0, 90), time, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).OnComplete(() => indicator.transform.DOPunchScale(Vector3.one / 3, .2f, 10, 1).SetUpdate(true));
    }


    Vector3 SpawnPos()
    {
        var transform1 = myCam.transform;
        return transform1.position + (transform1.forward * .5f) + (transform1.up * -.02f);
    }


}
