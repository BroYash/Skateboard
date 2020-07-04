using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedEmemy : MonoBehaviour
{
    private SkinnedMeshRenderer color;
    private Rigidbody rb;
    private BoxCollider bc;
    private bool isMoving;
    public float speed = 1.01f;
    public float maxV = 3.0f;

    private ArrayList playerObverser;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bc = this.GetComponent<BoxCollider>();
        isMoving = true;
        GetComponent<Animator>().StartPlayback();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.z <= 10 * maxV)
        {
            rb.AddForce(0, 0, speed);
        }
        isMoving = true;
    }
}
