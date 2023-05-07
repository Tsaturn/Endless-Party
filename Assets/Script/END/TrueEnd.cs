using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEnd : MonoBehaviour
{

    public GameObject _End;
    public GameObject _TrueEnd;

    public void End()
    {
        _End.GetComponent<End>().ind = 6;
        _End.SetActive(true);
        Invoke("OutEnd", 7);
    }
    public void OutEnd()
    {
        _TrueEnd.SetActive(true);
    }
}
