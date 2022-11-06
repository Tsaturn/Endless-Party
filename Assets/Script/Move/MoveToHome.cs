using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHome : MonoBehaviour
{
    public GameObject player;
    public GameObject button;

    public void MoveToLocation(int ind)
    {
        switch (ind)
        {
            case 1:
                player.GetComponent<Transform>().position = new Vector3(-5.258f, -22.208f, 0);
                break;
            default:
                break;
        }
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
