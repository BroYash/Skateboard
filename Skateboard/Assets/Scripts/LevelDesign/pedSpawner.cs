using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class pedSpawner : MonoBehaviour
{
    public int chance = 14;
    public int column = 2;
    public int size = 6;
    public float distance = 5.0f;
    public int spreadx;
    public int spreadz;

    public GameObject charactersPrefab;
    
    private Random random = new Random();

    private GameObject[] pedList;
    private GameObject[] activePedsSkins;
    private float nx;
    private float ny;
    private float nz;
    private bool NotfirstTime;
    




    // Start is called before the first frame update

    void Start()
    {
        NotfirstTime = false;
        activePedsSkins = new GameObject[size];
        pedList = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            pedList[i] = Instantiate(charactersPrefab, this.transform, false);
        }
        makePed();
        NotfirstTime = true;
    }

    public void makePed()
    {
        reskinPeds();
        reposPeds();
    }
    
    
    // change the peds skins
    private void reskinPeds()
    {
        
        resetCharacters();



        int randChar;
        for (int i = 0; i < size; i++)
        {
            randChar = random.Next(0, chance);
            if (randChar < 9)
            {

                pedList[i].SetActive(true);
                activePedsSkins[i] = pedList[i].transform.GetChild(randChar).gameObject;
                activePedsSkins[i].SetActive(true);
            }
            else
            {
                pedList[i].SetActive(false);
            }
        }
    }

    private void resetCharacters()
    {
        if (NotfirstTime)
        {
            for (int i = 0; i < size; i++)
            {
                activePedsSkins[i].SetActive(false);
            }
        }
    }

    //re position the peds
    private void reposPeds()
    {
        nx = transform.position.x - distance;
        ny = transform.position.y;
        nz = transform.position.z - distance;

        int c = 0;
        int ranx;
        int ranz;

        for (int i = 0; i < size; i++)
        {
            ranx = random.Next(-spreadx, spreadx);
            ranz = random.Next(-spreadz, spreadz);
            pedList[i].GetComponent<Transform>().position = new Vector3(nx + ranx, ny, nz + ranz);

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
}
