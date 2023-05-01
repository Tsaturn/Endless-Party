using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BFSpawn : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 3f);
    }

    private void Spawn()
    {
        System.Random r = new System.Random();
        int rand = r.Next(0, spawnList.Count - 1);
        if (spawnList[rand].GetComponent<BFObject>().inv)
        {
            spawnList[rand].GetComponent<BFObject>().SpawnObj();
            spawnList[rand].GetComponent<BFObject>().inv = false;
        }
        else Invoke("Spawn", 0.1f);


    }
}
