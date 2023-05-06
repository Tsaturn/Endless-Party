using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Cat : MonoBehaviour
{
    public GameObject player;
    public GameObject button;
    public GameObject diaglog;
    public int count = 1;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textName;
    public TMP_FontAsset font;

    public Image[] images;

    public GameObject[] ON;
    public GameObject[] OFF;

    public GameObject _End;
    public GameObject _catEnd;

    [Header("MiniGame")]
    public Camera mainCamera;
    public Camera gameCamera;
    public GameObject GRCatGame;
    public void PlayGame()
    {
        GRCatGame.SetActive(true);
        gameCamera.enabled = true;
        gameCamera = Camera.main;
        player.active = false;
    }
    public void Dialog()
    {
        switch (count)
        {
            case 1:
                diaglog.SetActive(true);
                text.text = "Мрррр.....";
                count++;
                break;
            case 2:
                diaglog.SetActive(true);
                text.text = "Мурмяу!";
                count++;
                break;
            case 3:
                diaglog.SetActive(true);
                text.text = "Мр...мр...мр...";
                count++;
                break;
            case 4:
                diaglog.SetActive(true);
                text.text = "*Нежный зевок*";
                count++;
                break;
            case 5:
                diaglog.SetActive(true);
                text.text = "Вообще, я предпочитаю, чтобы меня называли просто Борис.";
                count++;
                break;
            case 6:
                diaglog.SetActive(true);
                text.text = "*Мурчит*";
                count++;
                break;
            case 7:
                diaglog.SetActive(true);
                text.text = "Что? В чём секрет моей энергии?";
                count++;
                break;
            case 8:
                diaglog.SetActive(true);
                text.text = "Думаю, в сне по 16 часов в сутки.";
                count++;
                break;
            case 9:
                diaglog.SetActive(true);
                text.text = "*Облизывается*";
                count++;
                break;
            case 10:
                diaglog.SetActive(true);
                text.text = "Человек, а ты не устал по мне тыкать?";
                count++;
                break;
            case 11:
                diaglog.SetActive(true);
                text.text = "Нет, серьёзно, сколько можно?";
                count++;
                break;
            case 12:
                diaglog.SetActive(true);
                text.text = "Последнее предупреждение, кожаный!";
                count++;
                PlayGame();
                break;

                

            case 666:
                diaglog.SetActive(true);

                foreach (var item in images)
                    item.color = Color.red;

                textName.color = Color.red;
                textName.font = font;
                textName.text = "БОРИС";

                text.color = Color.red;
                text.fontSize = 14;
                text.font = font;
                text.text = "ТЫ НАДОЕЛ МНЕ, ЧЕЛОВЕК!";
                count++;
                foreach (var x in ON)
                    x.SetActive(true);
                foreach (var x in OFF)
                    x.SetActive(false);


                _End.GetComponent<End>().ind = 0;
                _End.SetActive(true);
                Invoke("CatEnd", 7);
                break;

            case 777:
                diaglog.SetActive(true);
                text.text = "Ладно, я прощаю твоё невежество, лысая обезьяна.";
                break;

        }
    }

    public void CatEnd()
    {
        _catEnd.SetActive(true);
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
            diaglog.SetActive(false);
        }
    }
}
