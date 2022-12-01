using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dm;

    public GameObject Player;


    [Header("Монологи Игрока")]
    public Dialogue Spawn_0;
    public Dialogue Spawn_1;
    public Dialogue Spawn_2;
    public Dialogue Spawn_3;
    public Dialogue Spawn_4;
    public Dialogue Spawn_5;

    [Header("Диалоги NPC")]
    public Dialogue Tony_dialogue;
    public Dialogue Test_dialogue;
    public Dialogue Test2_dialogue;

    //Некоторые функции
    public void CantMove()
    {
        Player.GetComponent<Move>().enabled = false;
        Player.GetComponent<Animator>().enabled = false;
        Player.GetComponent<AudioSource>().enabled = false;
    }
    public void CanMove()
    {
        if (dm.counter == 0)
        {
            Player.GetComponent<Move>().enabled = true;
            Player.GetComponent<Animator>().enabled = true;
            Player.GetComponent<AudioSource>().enabled = true;
        }
    }

    //Монологи игрока
    public void Spawn0_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_0);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void Spawn1_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_1);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void Spawn2_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_2);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void Spawn3_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_3);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void Spawn4_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_4);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void Spawn5_TriggerDialogue()
    {
        dm.StartDialogue(Spawn_5);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }



    //Диалоги с NPC
    public void Tony_TriggerDialogue() //Диалог с Тони
    {
        dm.StartDialogue(Tony_dialogue);
    }



    public void Test_TriggerDialogue() //Запуск диалога
    {
        dm.StartDialogue(Test_dialogue); //Какой диалог запускать
        InvokeRepeating("Test2_TriggerDialogue", 0, 1); //Штука каждую секунду пытается запустить функцию/
    }                                                   //                                              /
    public void Test2_TriggerDialogue()//Вот эту вот <________________________________________________/\______________________________/\
    {                           //                                                                                                      \
        if (dm.counter == 0)    //Если в прошлом диалоге закончился текст...                                                             \
        {                       //                                                                                                        \
            Player.GetComponent<SpriteRenderer>().color = Color.red; //Происходит что-то(Не важно что, строчка со сменой цвета для проверки)/
            dm.StartDialogue(Test2_dialogue);   //И запускается другой диалог                                                            /
            CancelInvoke("Test2_TriggerDialogue");  //А штука перестаёт пытаться каждую секунду запустить функцию ----------------------/
        }
    }
}
