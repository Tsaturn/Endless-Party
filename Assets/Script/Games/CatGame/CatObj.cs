using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatObj : MonoBehaviour
{
    public float speed = 0;
    public GameObject border;

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
}
