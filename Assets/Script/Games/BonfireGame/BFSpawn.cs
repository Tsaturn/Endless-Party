using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BFSpawn : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();
    private bool speedchanger = false;
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 3f);
    }
    private void Update()
    {
        if (!speedchanger)
            if (spawnList[0].GetComponent<BFObject>().speed <= -6f)
            {
                speedchanger = true;
                CancelInvoke("Spawn");
                InvokeRepeating("Spawn", 0, 2f);
            }
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
