using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    public GameObject button;


    public void OnTriggerEnter2D(Collider2D collision)	//���������� ��� ������������ ������� ���������� �� �������
    {
        startAnim.SetBool("startOpen", true);
        button.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        startAnim.SetBool("startOpen", false);
        button.SetActive(false);
        dm.EndDialogue();
    }
}
