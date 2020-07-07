using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{

    public List<GameObject> spawnLeft;
    public List<GameObject> spawnRight;
    public GameObject prefab;

    private void Start()    
    {
        SpawnLeft();
        SpawnRight();

    }

    private void SpawnLeft()
    {
        int i = Random.Range(0, spawnLeft.Count);
        GameObject car = Instantiate(prefab, spawnLeft[i].transform.position, Quaternion.Euler(0f, 180f, 0f));
        car.GetComponent<Traffic_car>().speed = -car.GetComponent<Traffic_car>().speed;
    }
    private void SpawnRight()
    {
        int j = Random.Range(0, spawnRight.Count);
        Instantiate(prefab, spawnRight[j].transform.position, Quaternion.identity);
    }


}
