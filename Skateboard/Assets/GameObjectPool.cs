using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject[] roadPrefabArray;
    public GameObject[] trashCanArray;

    public GameObject roadPrefab;
    public GameObject trashCanPrefab;

    public int roadIndex;

    public int tcIndex;

    private Vector3 newRoadPosition;
    private Vector3 trashCanPosition;

    private playerController pc;
    private OnRoadSpawn car;



    private void Start()
    {
        car = FindObjectOfType<OnRoadSpawn>();
        pc = FindObjectOfType<playerController>();

        roadPrefabArray = new GameObject[4];
        roadIndex = -1;

        trashCanArray = new GameObject[6];
        tcIndex = -1;

        newRoadPosition = new Vector3(0, 0, 97);
        trashCanPosition = new Vector3(-6, 0.1f, 42);

        for (int i = 0; i < 4; i++)
        {
            roadPrefabArray[i] = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);
            newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        }

        for (int i = 0; i < 4; i++)
        {
            trashCanArray[i] = Instantiate(trashCanPrefab, trashCanPosition, Quaternion.identity);
            trashCanPosition = trashCanPosition + new Vector3(0, 0, 97);
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
        SpawnCars.isSpawn = true;
        this.car.spawn();
        newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        roadIndex++;
    }

    public void spawnTrashCan()
    {
        int i = Random.Range(0, 2);

        if (tcIndex == -1)
        {
            tcIndex = 0;
            return;
        }
        if (tcIndex > trashCanArray.Length - 1)
        {
            tcIndex = 0;
        }
        
        if(i == 0)
        {
            trashCanArray[tcIndex].transform.position = trashCanPosition;
        }
        else
        {
            trashCanArray[tcIndex].transform.position = trashCanPosition + new Vector3(13, 0, 0);
        }

        trashCanPosition = trashCanPosition + new Vector3(0, 0, 97 + Random.Range(-50, 50));
        tcIndex++;
    }
}
