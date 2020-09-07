using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement1 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject hitParticlePrefab;

    private GameObject healthBar;
    private Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("---UI/Canvas/HealthBar");
        healthSlider = healthBar.GetComponent<Slider>();
        
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.layer == 14)
        {
            BodyPartScript bp = collision.gameObject.GetComponent<BodyPartScript>();

            //if (!bp.enemy.dead)
                Instantiate(hitParticlePrefab, transform.position, transform.rotation);

            bp.HidePartAndReplace();
            bp.enemy.Ragdoll();
            Debug.Log("Enemy killed!");
            
            collision.gameObject.tag = "Dead";
            collision.gameObject.layer = 13;
            SetLayerRecursively(collision.gameObject, 13);
            
            GlobalVar.EnemyNo--;

            if (GlobalVar.EnemyNo == 0)
            {
                GlobalVar.IsWin = true;
            }
        }
        
        Destroy(gameObject);
    }
    
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }
           
        obj.layer = newLayer;
           
        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
    
    void TakeDamage(int damage)
    {
        GlobalVar.currentHealth -= damage;
        // healthBar.SetHealth(GlobalVar.currentHealth);
    }
}
