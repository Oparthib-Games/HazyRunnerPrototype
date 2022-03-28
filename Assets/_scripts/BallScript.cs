using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody RB;
    Animator anim;

    public float sphereRadius = 0.6f;
    public float rayDistance = 1f;
    public Vector3 moveForce = new Vector3(0, 0, 0);
    public Vector3 smashForce = new Vector3(0, 0, 0);

    public bool isDropped;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //RB.AddForce(moveForce, ForceMode.Impulse);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(smashForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        StretchAndSquash();
    }

    private void StretchAndSquash()
    {
        Ray ray = new Ray(transform.position + transform.up * -sphereRadius, transform.up * -1);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && !isDropped)
        {
            anim.SetBool("squash", true);
            //anim.SetTrigger("squash");

            isDropped = true;
        }
        else
        {
            anim.SetBool("squash", false);
            isDropped = false;
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    public void ApplyForce()
    {
        RB.AddForce(moveForce, ForceMode.Impulse);
    }
}
