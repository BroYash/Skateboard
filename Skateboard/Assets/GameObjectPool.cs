using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject[] roadPrefabArray;
    public GameObject[] trashCanArray;

    public GameObject roadPrefab;
    public int roadIndex;
    private Vector3 newRoadPosition;
    private playerController pc;
    private OnRoadSpawn car;



    private void Start()
    {
        car = FindObjectOfType<OnRoadSpawn>();
        roadPrefabArray = new GameObject[4];
        roadIndex = -1;
        pc = FindObjectOfType<playerController>();

        newRoadPosition = new Vector3(0, 0, 97);
        for (int i = 0; i < 4; i++)
        {
            roadPrefabArray[i] = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);
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
        Debug.Log(roadPrefabArray.Length);
        if(roadIndex > roadPrefabArray.Length-1)
        {
            roadIndex = 0;
        }
        roadPrefabArray[roadIndex].transform.position = newRoadPosition;
        
        newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        roadIndex++;
    }

    public void spawnTrashCan()
    {
        int i = Random.Range(0, 2);

        if (roadIndex == -1)
        {
            roadIndex = 0;
            return;
        }
        Debug.Log(roadPrefabArray.Length);
        if (roadIndex > roadPrefabArray.Length - 1)
        {
            roadIndex = 0;
        }
        roadPrefabArray[roadIndex].transform.position = newRoadPosition;

        newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        roadIndex++;
    }
}
