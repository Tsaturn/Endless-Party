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

    [Header("Диалог с Тони")]
    public Dialogue Tony_dialogue;

    [Header("Диалог с Энни")]
    public Dialogue EnnyAnek_dialogue;
    public Dialogue EnnyAnek2_dialogue;
    public Dialogue EnnyFlirt_dialogue;
    public Dialogue EnnyFlirt2_dialogue;
    public Dialogue EnnyHello_dialogue;
    public Dialogue EnnyHello2_dialogue;
    private int enny_counter = 0;
    public GameObject anek;
    public GameObject flirt;
    public GameObject hello;

    [Header("Диалог с Петькой и Василием Ивановичем")]
    public Dialogue PetkaVasiliy1_dialogue;
    public Dialogue PetkaVasiliy2_dialogue;
    public Dialogue PetkaVasiliy3_dialogue;
    public Dialogue PetkaVasiliy4_dialogue;
    private int petkavasiliy_counter = 1;

    [Header("Диалог с Охраником")]
    public Dialogue Guard_dialogue;

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
            CancelInvoke("CanMove");
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
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }

    //Диалоги с Энни
    public void EnnyShowButtonsOrDialog()
    {
        switch (enny_counter)
        {
            case 0:
                anek.SetActive(true);
                flirt.SetActive(true);
                hello.SetActive(true);
                break;
            case 1:
                EnnyAnek2();
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;
            case 2:
                EnnyFlirt2();
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;
            case 3:
                EnnyHello2();
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;

            default:
                break;
        }
    }
    public void EnnyOffButtons()
    {
        if (dm.counter == 0)
        {
            anek.SetActive(false);
            flirt.SetActive(false);
            hello.SetActive(false);
            CancelInvoke("EnnyOffButtons");
        }
    }
    public void EnnyAnek()
    {
        dm.StartDialogue(EnnyAnek_dialogue);
        enny_counter = 1;
        InvokeRepeating("EnnyOffButtons", 0, 1);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void EnnyAnek2()
    {
        dm.StartDialogue(EnnyAnek2_dialogue);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void EnnyFlirt()
    {
        dm.StartDialogue(EnnyFlirt_dialogue);
        enny_counter = 2;
        InvokeRepeating("EnnyOffButtons", 0, 1);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void EnnyFlirt2()
    {
        dm.StartDialogue(EnnyFlirt2_dialogue);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void EnnyHello()
    {
        dm.StartDialogue(EnnyHello_dialogue);
        enny_counter = 3;
        InvokeRepeating("EnnyOffButtons", 0, 1);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }
    public void EnnyHello2()
    {
        dm.StartDialogue(EnnyHello2_dialogue);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
    }

    //Диалог с Петькой и Василием Ивановичем
    public void PetkaVasiliy()
    {
        switch (petkavasiliy_counter)
        {
            case 1:
                dm.StartDialogue(PetkaVasiliy1_dialogue);
                petkavasiliy_counter++;
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;
            case 2:
                dm.StartDialogue(PetkaVasiliy2_dialogue);
                petkavasiliy_counter++;
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;
            case 3:
                dm.StartDialogue(PetkaVasiliy3_dialogue);
                petkavasiliy_counter++;
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;
            case 4:
                dm.StartDialogue(PetkaVasiliy4_dialogue);
                petkavasiliy_counter = 1;
                CantMove();
                InvokeRepeating("CanMove", 0, 1);
                break;


            default:
                break;
        }
    }

    //Диалог с охранником
    public void GuardDialog()
    {
        dm.StartDialogue(Guard_dialogue);
        CantMove();
        InvokeRepeating("CanMove", 0, 1);
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
