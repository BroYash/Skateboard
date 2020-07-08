using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject[] E;
    public GameObject roadPrefab;
    public int roadIndex;
    private Vector3 newRoadPosition;
    private playerController pc;
    private OnRoadSpawn car;

    private void Start()
    {
        car = FindObjectOfType<OnRoadSpawn>();
        E = new GameObject[4];
        roadIndex = -1;
        pc = FindObjectOfType<playerController>();

        newRoadPosition = new Vector3(0, 0, 97);
        for (int i = 0; i < 4; i++)
        {
            E[i] = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);
            newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        }
    }

    public void spawnRoads()
    {
        if (roadIndex == -1)
        {
            roadIndex = 0;
            return;    
        }
        Debug.Log(E.Length);
        if(roadIndex > E.Length-1)
        {
            roadIndex = 0;
        }
        E[roadIndex].transform.position = newRoadPosition;
        
        newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        roadIndex++;
    }
}
