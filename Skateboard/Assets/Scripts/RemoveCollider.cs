using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Collider[] colliders;
    void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        for (int i = colliders.Length - 1 ; i >= 0; i --)
        {
            colliders[i].enabled = false;
        }
    }

}
