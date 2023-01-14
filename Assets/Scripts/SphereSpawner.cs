using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNight;

public class SphereSpawner : MonoBehaviour
{
    public GameObject[] levels;
    public static bool readyToSpawn = true;

    private void Start()
    {
        readyToSpawn = true;
    }
    void Update()
    {
        if(readyToSpawn == true)
        {
            Instantiate(levels[Random.Range(0, levels.Length)], new Vector3(0,0,0), Quaternion.identity);
            readyToSpawn = false;
        }
    }  
}
