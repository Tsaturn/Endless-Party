using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOut : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private Camera cam;

    public void MoveToLocation(int ind)
    {
        switch (ind)
        {
            case 1:
                player.GetComponent<Transform>().position = new Vector3(-5.152838f, 0.5087408f, 0);
                player.GetComponent<AudioSource>().clip = _audio;
                cam.transform.position = player.transform.position;
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
