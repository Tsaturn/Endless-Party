using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public GameObject player;
    public GameObject button;

    public GameObject _End;
    public GameObject _bonfireEnd;

    public Camera mainCamera;

    [Header("MiniGame")]
    public Camera gameCamera;
    public GameObject BonfireGame;
    public void PlayGame()
    {
        BonfireGame.SetActive(true);
        gameCamera.enabled = true;
        gameCamera = Camera.main;
        player.active = false;
    }

    public void End()
    {
        _End.GetComponent<End>().ind = 2;
        _End.SetActive(true);
        Invoke("OutEnd", 7);
    }

    public void OutEnd()
    {
        _bonfireEnd.SetActive(true);
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
