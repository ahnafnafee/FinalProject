using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public class WeaponScript1 : MonoBehaviour
{
    public Camera myCam;
    public GameObject target;
    public GameObject bulletPrefab;
    
    [Header("Bools")]
    public bool active = true;
    public bool reloading;

    private Rigidbody rb;
    private Collider collider;
    private Renderer renderer;

    [Space]
    [Header("Weapon Settings")]
    public float reloadTime = .3f;
    public int bulletAmount = 6;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();

        ChangeSettings();
    }

    void ChangeSettings()
    {
        if (transform.parent != null)
            return;

        rb.isKinematic = (SuperHotScript.instance.weapon == this) ? true : false;
        rb.interpolation = (SuperHotScript.instance.weapon == this) ? RigidbodyInterpolation.None : RigidbodyInterpolation.Interpolate;
        collider.isTrigger = (SuperHotScript.instance.weapon == this);
    }

    public void Shoot(Vector3 pos,Quaternion rot, bool isEnemy)
    {
        if (reloading)
            return;

        if (bulletAmount <= 0)
            return;

        // if(!SuperHotScript.instance.weapon == this)
        //     bulletAmount--;

        GameObject bullet = Instantiate(bulletPrefab, pos, rot);

        if (GetComponentInChildren<ParticleSystem>() != null)
            GetComponentInChildren<ParticleSystem>().Play();

        if(SuperHotScript1.instance.weapon == this)
            StartCoroutine(Reload());

        target.transform.DOComplete();
        target.transform.DOShakePosition(.2f, .01f, 10, 90, false, true).SetUpdate(true);

        // if(SuperHotScript.instance.weapon == this)
        //     transform.DOLocalMoveZ(-.1f, .05f).OnComplete(()=>transform.DOLocalMoveZ(0,.2f));
    }

    public void Throw()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOMove(transform.position - transform.forward, .01f)).SetUpdate(true);
        s.AppendCallback(() => transform.parent = null);
        s.AppendCallback(() => transform.position = myCam.transform.position + (myCam.transform.right * .1f));
        s.AppendCallback(() => ChangeSettings());
        s.AppendCallback(() => rb.AddForce(myCam.transform.forward * 10, ForceMode.Impulse));
        s.AppendCallback(() => rb.AddTorque(transform.transform.right + transform.transform.up * 20, ForceMode.Impulse));
    }

    IEnumerator Reload()
    {
        if (SuperHotScript1.instance.weapon != this)
            yield break;
        // SuperHotScript1.instance.ReloadUI(reloadTime);
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && collision.relativeVelocity.magnitude < 15)
        {
            BodyPartScript bp = collision.gameObject.GetComponent<BodyPartScript>();

            if (!bp.enemy.dead)
                Instantiate(SuperHotScript.instance.hitParticlePrefab, transform.position, transform.rotation);

            bp.HidePartAndReplace();
            bp.enemy.Ragdoll();
        }

    }

}
