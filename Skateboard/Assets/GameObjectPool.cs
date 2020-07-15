using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject[] roadPrefabArray;
    public GameObject[] trashCanArray;
    public GameObject[] vehicleArray;

    public GameObject roadPrefab;
    public GameObject trashCanPrefab;
    public GameObject vehiclePrefab;

    public int roadIndex;

    public int tcIndex;

    public int vehicleIndex;

    private Vector3 newRoadPosition;
    private Vector3 trashCanPosition;
    private Vector3 vehiclePosition1;
    private Vector3 vehiclePosition2;

    private playerController pc;
    private OnRoadSpawn car;



    private void Start()
    {
        car = FindObjectOfType<OnRoadSpawn>();
        pc = FindObjectOfType<playerController>();

        roadPrefabArray = new GameObject[4];
        roadIndex = -1;

        trashCanArray = new GameObject[4];
        tcIndex = -1;

        vehicleArray = new GameObject[10];
        vehicleIndex = -1;

        newRoadPosition = new Vector3(0, 0, 97);
        trashCanPosition = new Vector3(-6, 0, 42);
        vehiclePosition1 = new Vector3(-2.33f, 0.1f, 42);
        vehiclePosition2 = new Vector3(2.8f, 0.1f, 53.9f);

        for (int i = 0; i < roadPrefabArray.Length; i++)
        {
                roadPrefabArray[i] = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);
                newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        }
        for (int i = 0; i < trashCanArray.Length; i++)
        {
                trashCanArray[i] = Instantiate(trashCanPrefab, trashCanPosition, Quaternion.identity);
                int r = Random.Range(0, 2);
                if (r == 0)
                {
                    trashCanArray[i] = Instantiate(trashCanPrefab, trashCanPosition, Quaternion.identity);
                }
                else
                {
                    trashCanArray[i] = Instantiate(trashCanPrefab, trashCanPosition + new Vector3(13, 0, 0), Quaternion.identity);
                }
                trashCanPosition = trashCanPosition + new Vector3(0, 0, 97);
        }
        for (int i = 0; i < vehicleArray.Length; i++)
        {
            vehicleArray[i] = Instantiate(vehiclePrefab, vehiclePosition1, Quaternion.Euler(0f, 180f, 0f));
            vehicleArray[i].GetComponent<Traffic_car>().speed = -vehicleArray[i].GetComponent<Traffic_car>().speed;
            i++;
            vehicleArray[i] = Instantiate(vehiclePrefab, vehiclePosition2, Quaternion.Euler(0f, 180f, 0f));
            vehicleArray[i].GetComponent<Traffic_car>().speed = -vehicleArray[i].GetComponent<Traffic_car>().speed;
            vehiclePosition1 = vehiclePosition1 + new Vector3(0, 0, 97);
            vehiclePosition2 = vehiclePosition2 + new Vector3(0, 0, 97);
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
        if (tcIndex == -1)
        {
            tcIndex = 0;
            return;
        }
        if (tcIndex > trashCanArray.Length - 1)
        {
            tcIndex = 0;
        }
        int r = Random.Range(0, 2);
        if (r == 0)
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
    public void spawnVehicle()
    {
        if (vehicleIndex == -1)
        {
            vehicleIndex = 0;
            return;
        }
        if (vehicleIndex > vehicleArray.Length - 1)
        {
            vehicleIndex = 0;
        }
        vehicleArray[vehicleIndex].transform.position = vehiclePosition1;  
        vehiclePosition1 = vehiclePosition1 + new Vector3(0, 0, 97);
        vehicleIndex++;
        vehicleArray[vehicleIndex].transform.position = vehiclePosition2;
        vehiclePosition2 = vehiclePosition2 + new Vector3(0, 0, 97);
        vehicleIndex++;
    }
}

