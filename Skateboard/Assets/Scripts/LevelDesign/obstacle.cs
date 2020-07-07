using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private playerController pc;
        
    void Start()
    {
        pc = FindObjectOfType<playerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.ToggleDead();
        }

    }
}
