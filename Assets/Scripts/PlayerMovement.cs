using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _z, _x;
    public Animator playerAnim;
    
    public float zSpeed = 4, xSpeed = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Vertical")) 
        {
            //FORWARD MOVEMENT
            _z = Input.GetAxis("Vertical") * Time.deltaTime * zSpeed;
            playerAnim.SetTrigger("run");

            transform.Translate(0, 0, _z);
        }
        else if (Input.GetButton("Horizontal"))
        {
            //SIDE MOVEMENT
            _x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
            transform.Translate(_x, 0, 0);
            playerAnim.SetTrigger("strafe");
        }
        else
        {
            playerAnim.SetTrigger("idle");
        }
    }
}
