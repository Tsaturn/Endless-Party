using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject _interface;
    public GameObject player;
    public GameObject fon;

    public bool[] EndingOn;
    public int ind = -1;

    private const string saveKey = "EndSave";

    public void Awake()
    {
        Load();
        if (ind != - 1) EndingOn[ind] = true;
    }
    public void Start()
    {
        Save();
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

    public void Load()
    {
        var data = SaveManager.Load<SaveData.End>(saveKey);

        EndingOn = data.End_On;
    }

    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }
    private SaveData.End GetSaveSnapshot()
    {
        var data = new SaveData.End()
        {
            End_On = EndingOn,
        };
        return data;
    }
}
