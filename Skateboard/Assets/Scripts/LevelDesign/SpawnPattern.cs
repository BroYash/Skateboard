using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnPattern : MonoBehaviour
{
    public int column = 3;
    public int size = 9;
    public float distance = 5.0f;

    public GameObject[] charactersPrefab; 

    private GameObject[] objectList;
    private float nx;
    private float ny;
    private float nz;
    private int c;

    
   
    // Start is called before the first frame update

    void Start()
    {
        
        Random random = new Random();

        nx = transform.position.x - distance;
        ny = transform.position.y;
        nz = transform.position.z - distance;

        objectList = new GameObject[size];
        c = 0;
        int ranx;
        int randchar;
        int randSize = random.Next(1,size+1);
        for (int i = 0; i < randSize; i++)
        {
            ranx = random.Next(-1, 1);
            randchar = random.Next(0,9);
            objectList[i] = Instantiate(charactersPrefab[randchar], this.transform, false);
            objectList[i].GetComponent<Transform>().position = new Vector3(nx - ranx, ny, nz - ranx);
            

            nx += distance;
            c++;
            if (c == column)
            {
                nx -= column * distance;
                nz += distance;
                c = 0;            
            }
        }
    }

    // add a model instead of an empty gameObject
    public void addObject(GameObject newObject, int index = -1)
    {
        
    }
    
}
