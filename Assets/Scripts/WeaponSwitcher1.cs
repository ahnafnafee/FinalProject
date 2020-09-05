using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher1 : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject grappleGun;

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1)) weapons[0].SetActive(true);
        if (Input.GetKeyDown(KeyCode.Alpha2)) grappleGun.GetComponent<GrapplingGun>().isActive = true;
    }

    // private void DeactivateAll()
    // {
    //     for (int i = 0; i < weapons.Length; i++)
    //     {
    //         //exclude grappleGun
    //         if (i != 1)
    //             weapons[i].SetActive(false);
    //         else
    //             grappleGun.GetComponent<GrapplingGun>().isActive = false;
    //     }
    // }
}
