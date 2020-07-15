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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            pool.spawnTrashCan();
            pool.spawnVehicle();
            pool.spawnRoads();
            
        }

    }
}
