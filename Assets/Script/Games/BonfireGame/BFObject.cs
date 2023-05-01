using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFObject : MonoBehaviour
{
    public float speed = -1;
    public bool inv = false;
    public GameObject border;

    private void Start()
    {
        InvokeRepeating("Speed", 2, 2);
    }
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (border.transform.position.x - transform.position.x >= 0) inv = true;

    }

    public void Speed() { speed += -0.1f; }
    public void SpawnObj()
    {
        transform.position = new Vector3(-37.4f, 12, -1);
    }
}
