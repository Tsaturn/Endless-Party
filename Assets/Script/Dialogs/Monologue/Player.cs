using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DialogueTrigger dt;
    public int d_ind = 0;

    //0 - ничего не сделано, 1 - квест выполнен, 2 - квест провален, 3 - больше не запускать этот диалог
    public Dictionary<string, int> Quest = new Dictionary<string, int>();

    private const string saveKey = "PlayerSave";
    public void Start()
    {
        Load();
        Invoke("ShowDialog", 1);
        Quest["Sigward"] = 0;
    }

    public void ShowDialog()
    {
        switch (d_ind)
        {
            case 0:
                dt.Spawn0_TriggerDialogue();
                d_ind++;
                Save();
                break;
            case 1:
                dt.Spawn1_TriggerDialogue();
                d_ind++;
                Save();
                break;
            case 2:
                dt.Spawn2_TriggerDialogue();
                d_ind++;
                Save();
                break;
            case 3:
                dt.Spawn3_TriggerDialogue();
                d_ind++;
                Save();
                break;
            case 4:
                dt.Spawn4_TriggerDialogue();
                d_ind++;
                Save();
                break;


            default:
                dt.Spawn5_TriggerDialogue();
                d_ind++;
                Save();
                break;
        }
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.Player>(saveKey);

        d_ind = data.d_ind;
    }

    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }
    private SaveData.Player GetSaveSnapshot()
    {
        var data = new SaveData.Player()
        {
            d_ind = this.d_ind,
        };
        return data;
    }
}
