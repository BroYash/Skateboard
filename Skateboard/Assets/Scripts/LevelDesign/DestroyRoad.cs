using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    public GameObject _object;
    private playerController pc;

    public void Start()
    {
        pc = FindObjectOfType<playerController>();
    }



    private void Update()
    {
        if (pc != null)
        {

        }
        if(pc.transform.position.z > _object.transform.position.z)
        {
            Destroy(gameObject);
        }
        
    }
}
