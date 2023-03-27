using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galochka : MonoBehaviour
{
    public GameObject player;

    public GameObject _End;
    public GameObject _galochkaEnd;

    public void End()
    {
        _End.GetComponent<End>().ind = 4;
        _End.SetActive(true);
        InvokeRepeating("CantMove", 0,1);
        Invoke("OutEnd", 7);
    }

    public void CantMove()
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
    }

    public void OutEnd()
    {
        _galochkaEnd.SetActive(true);
    }
}
