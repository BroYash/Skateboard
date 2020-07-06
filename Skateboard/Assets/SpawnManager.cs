using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 newRoadPosition;

    [SerializeField] GameObject roadPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        newRoadPosition = new Vector3(2.307844f, 0.4388793f, 346.5219f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRoad()
    {
        Instantiate(roadPrefab, transform.position = newRoadPosition, Quaternion.identity);

        newRoadPosition = newRoadPosition + new Vector3(0,0, 87.1f + 1.878134f);
    }
}
