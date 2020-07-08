using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private CapsuleCollider cc;
    void Start()
    {
        cc = GetComponent<CapsuleCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // kills the player after 3 seconds
            Destroy(collision.gameObject,3.0f); 
                
        }
    }



}
