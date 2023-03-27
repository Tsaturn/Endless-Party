using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhyWaiterDialogueTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject waiter;
    public DialogueTrigger startdialogue;
    public int dialogue = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            if (dialogue == 1)
            {
                waiter.SetActive(false);
                startdialogue.Why1Dialog();
            }
            if (dialogue == 2)
            startdialogue.Why2Dialog();
            this.enabled = false;
        }
    }
}
