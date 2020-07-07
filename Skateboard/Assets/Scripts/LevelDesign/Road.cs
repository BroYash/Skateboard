using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private SpawnCars car;
    private GameObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<GameObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
