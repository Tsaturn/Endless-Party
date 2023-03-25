using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drakkar : MonoBehaviour
{
    public GameObject player;
    public GameObject button;

    public GameObject _End;
    public GameObject _drakkarEnd;

    public void End()
    {
        _End.GetComponent<End>().ind = 3;
        _End.SetActive(true);
        Invoke("OutEnd", 7);
    }

    public void OutEnd()
    {
        _drakkarEnd.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.SetActive(true);

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.SetActive(false);
        }
    }
}
