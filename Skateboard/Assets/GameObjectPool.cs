using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject[] E = new GameObject[4];
    public GameObject roadPrefab;
    public int roadIndex = 0;
    private Vector3 newRoadPosition;

    public GameObject _object;
    private playerController pc;

    private void Start()
    {
        pc = FindObjectOfType<playerController>();


        newRoadPosition = new Vector3(2.307844f, 0.4388793f, 0);
        for (int i = 0; i < 4; i++)
        {
            E[i] = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);
            newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        }
    }

    public void spawnRoads()
    {
        if(roadIndex > E.Length)
        {
            roadIndex = 0;
        }
        E[roadIndex].transform.position = newRoadPosition;
        newRoadPosition = newRoadPosition + new Vector3(0, 0, 97);
        roadIndex++;
    }
}
