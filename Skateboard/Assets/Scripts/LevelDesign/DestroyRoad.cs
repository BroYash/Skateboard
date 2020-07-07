using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    public GameObject _object;
    private playerController pc;
    private GameObjectPool pool;

    public void Start()
    {
        pc = FindObjectOfType<playerController>();
        pool = FindObjectOfType<GameObjectPool>();
    }



    private void Update()
    {
        if(pc.transform.position.z > _object.transform.position.z)
        {
            pool.spawnRoads();
        }
        
    }
}
