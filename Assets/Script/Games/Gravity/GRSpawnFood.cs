using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRSpawnFood : MonoBehaviour
{
    public GameObject right;
    public GameObject center;
    public GameObject left;

    GameObject nRight;
    GameObject nCenter;
    GameObject nLeft;

    void Start()
    {
        //nRight = Instantiate(right);
        //nCenter = Instantiate(center);
        //nLeft = Instantiate(left);
        //nRight.GetComponent<GRFood>().speed = -5;
        //nCenter.GetComponent<GRFood>().speed = -5;
        //nLeft.GetComponent<GRFood>().speed = -5;
        InvokeRepeating("Spawn", 1, 1f);
    }

    //private void Update()
    //{
    //    if (nRight == null) { nRight = Instantiate(right); nRight.GetComponent<GRFood>().speed = -5; }
    //    if (nCenter == null) { nRight = Instantiate(center); nCenter.GetComponent<GRFood>().speed = -5; }
    //    if (nLeft == null) { nRight = Instantiate(left); nLeft.GetComponent<GRFood>().speed = -5; }
    //}
    private void Spawn()
    {
        int rand = (int)System.Math.Round((double)Random.Range(1, 3.99f));
        switch (rand)
        {
            case 1:
                nRight = Instantiate(right);
                nRight.GetComponent<GRFood>().speed = -5;
                nRight.transform.position = right.transform.position;
                Instantiate(nRight);
                break;

            case 2:
                nCenter = Instantiate(center);
                nCenter.GetComponent<GRFood>().speed = -5;
                nCenter.transform.position = center.transform.position;
                Instantiate(nCenter);
                break;

            case 3:
                nLeft = Instantiate(left);
                nLeft.GetComponent<GRFood>().speed = -5;
                nLeft.transform.position = left.transform.position;
                Instantiate(nLeft);
                break;

            default:
                break;
        }
    }
}
