using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public bool[] EndingOn;
    public GameObject[] Endings;

    private const string saveKey = "EndSave";
    
    public void Start()
    {
        Load();
        for (int i = 0; i < EndingOn.Length; i++)
        {
            if (EndingOn[i]) Endings[i].SetActive(true);
            else Endings[i].SetActive(false);
        }
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData.End>(saveKey);

        EndingOn = data.End_On;
    }
}
