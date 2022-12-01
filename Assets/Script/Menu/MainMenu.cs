using System.Collections;
using System.Collections.Generic;
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
    }
    public void CalendarOff()
    {
        calendar.SetActive(false);
    }

    private const string saveKey = "PlayerSave";
    public void DeleteProgress()    //Сброс игрового прогресса
    {
        Save();
    }
    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }
    private SaveData.Player GetSaveSnapshot()
    {
        var data = new SaveData.Player()
        {
            d_ind = 0,
        };
        return data;
    }
}
