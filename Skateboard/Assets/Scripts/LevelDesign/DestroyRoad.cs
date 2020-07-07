using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    private playerController pc;
    private GameObjectPool pool;

    public void Start()
    {
        pc = FindObjectOfType<playerController>();
        pool = FindObjectOfType<GameObjectPool>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (pc.transform.position.z > this.transform.position.z)
        {

            pool.spawnRoads();

        }
    }
}
