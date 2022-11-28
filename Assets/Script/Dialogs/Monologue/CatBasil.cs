using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CatBasil : MonoBehaviour
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
                text.text = "*Мурчит*";
                count++;
                break;
            case 6:
                diaglog.SetActive(true);
                text.text = "Человек, а ты не устал по мне тыкать?";
                count++;
                break;
            case 7:
                diaglog.SetActive(true);
                text.text = "Нет, серьёзно, сколько можно?";
                count++;
                break;
            case 8:
                diaglog.SetActive(true);
                text.text = "Последнее предупреждение, кожаный!";
                count++;
                break;



            default:
                diaglog.SetActive(true);

                foreach (var item in images)
                    item.color = Color.red;

                textName.color = Color.red;
                textName.font = font;

                text.color = Color.red;
                text.fontSize = 14;
                text.font = font;
                text.text = "ТЫ НАДОЕЛ МНЕ, ЧЕЛОВЕК!";
                count++;
                foreach (var x in ON)
                    x.SetActive(true);
                foreach (var x in OFF)
                    x.SetActive(false);
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
            diaglog.SetActive(false);
        }
    }
}
