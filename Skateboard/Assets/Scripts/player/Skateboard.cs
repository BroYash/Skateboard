using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    public bool isGrounded;


    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
