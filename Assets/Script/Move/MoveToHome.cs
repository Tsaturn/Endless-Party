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
                player.GetComponent<Transform>().position = new Vector3(-5.258f, -22.208f, -1);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (button.activeSelf == true && Input.GetKeyDown(KeyCode.E)) MoveToLocation(1);
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
