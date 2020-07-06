using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour
{
    public GameObject[] objectList;
    public float distance = 5.0f;
    private float nx;
    private float ny;
    private float nz;
    private int c;
    // Start is called before the first frame update

    void Start()
    {


        nx = transform.position.x - distance;
        ny = transform.position.y;
        nz = transform.position.z - distance;

        GameObject blank = new GameObject();
        blank.AddComponent<BoxCollider>();

        objectList = new GameObject[9];
        c = 0;
        for (int i = 0; i < 9; i++)
        {
            
            objectList[i] = Instantiate(blank,this.transform,false); ;
            objectList[i].GetComponent<Transform>().position = new Vector3(nx, ny, nz);
            nx += distance;
            c++;
            if (c == 3)
            {
                nx -= 3 * distance;
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
