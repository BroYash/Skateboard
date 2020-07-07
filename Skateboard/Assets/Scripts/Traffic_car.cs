using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_car : MonoBehaviour
{
    public float speed = 15f;

    private Rigidbody rb;
    private Collider coll;
    private playerController pc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        pc = FindObjectOfType<playerController>();
    }

    private void Update()
    {

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        if(pc.transform.position.z > this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pc != null)
        {
            pc.ToggleDead();
        }

    }
}
