using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRoadSpawn : MonoBehaviour
{
    private SpawnCars car;
    public List<GameObject> spawnLeft;
    public List<GameObject> spawnRight;

    void Start()
    {
        //spawn();
    }

    public void spawn()
    {
        car = FindObjectOfType<SpawnCars>();
        car.Spawn(spawnLeft, spawnRight);
    }

}
