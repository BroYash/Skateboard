using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{

   
    public GameObject prefab;
    public static bool isSpawn = false;

    public void Spawn(List<GameObject> spawnLeft, List<GameObject> spawnRight)
    {
        SpawnLeft(spawnLeft);
        SpawnRight(spawnRight);
    }
    
    private void SpawnLeft(List<GameObject> spawnLeft)
    {
        int i = Random.Range(0, spawnLeft.Count);
        GameObject car = Instantiate(prefab,transform.position = spawnLeft[i].transform.position, Quaternion.Euler(0f, 180f, 0f));
        car.GetComponent<Traffic_car>().speed = -car.GetComponent<Traffic_car>().speed;
    }
    private void SpawnRight(List<GameObject> spawnRight)
    {
        
        int j = Random.Range(0, spawnRight.Count);

        
        Instantiate(prefab, transform.position = spawnRight[j].transform.position, Quaternion.identity);
    }


}
