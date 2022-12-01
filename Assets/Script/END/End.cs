using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject _interface;
    public GameObject player;
    public GameObject fon;

    public void Start()
    {
        Invoke("SetActiveInterface", 7);
        player.GetComponent<Move>().enabled = false;
        fon.SetActive(true);

    }

    public void SetActiveInterface()
    {
        _interface.SetActive(true);
        fon.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
