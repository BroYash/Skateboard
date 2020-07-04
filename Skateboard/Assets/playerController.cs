using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public float turnSpeed = 5f;
    public GameObject spawnPoint;


    private bool isGrounded;
    private Animator animator;
    private Rigidbody rb;
    private Collider coll;

    private void Awake()
    {
        this.transform.position = this.spawnPoint.transform.position;
        this.transform.Rotate(0, 0, 0);
        
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        Movement();
    }


    public void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        if(h < 0)
        {
            rb.velocity = new Vector3(-turnSpeed, rb.velocity.y, rb.velocity.z);
        }
        else if (h > 0)
        {
            rb.velocity = new Vector3(turnSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
                Jump();
        }

    }


    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);

        animator.SetBool("jump", true);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }


}
