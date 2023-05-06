using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public GameObject calendar;
    public void CalendarOn()
    {
        calendar.SetActive(true);
        calendar.GetComponent<Calendar>().Start();
    }
    public void CalendarOff()
    {
        calendar.SetActive(false);
    }

    private const string saveKey = "PlayerSave";
    private const string saveEndKey = "EndSave";
    public void DeleteProgress()    //Сброс игрового прогресса
    {
        Save();
    }
    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
        SaveManager.Save(saveEndKey, GetSaveEndSnapshot());
    }
    private SaveData.Player GetSaveSnapshot()
    {
        var data = new SaveData.Player()
        {
            d_ind = 0,
            Sigward= 0,
        };
        return data;
    }

    private bool[] temp = new bool[30];
    private SaveData.End GetSaveEndSnapshot()
    {
        for (int i = 0; i < temp.Length; i++)
            temp[i] = false;
        var data = new SaveData.End()
        {
            End_On = temp,
        };
        return data;
    }
}
