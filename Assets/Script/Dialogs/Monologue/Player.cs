using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DialogueTrigger dt;
    public int d_ind = 0;
    public GameObject Creator;
    public GameObject CreatorCanvas;

    //0 - ничего не сделано, 1 - квест выполнен, 2 - квест провален, 3 - больше не запускать этот диалог
    public Dictionary<string, int> Quest = new Dictionary<string, int>();
    private const string saveKey = "PlayerSave";
    public void Awake()
    {
        Load();
        if (!Quest.ContainsKey("Sigward"))
            Quest["Sigward"] = 0; 
        if (!Quest.ContainsKey("Cat"))
            Quest["Cat"] = 0; 
        if (!Quest.ContainsKey("Gal"))
            Quest["Gal"] = 0; 
        if (!Quest.ContainsKey("Vik"))
            Quest["Vik"] = 0; 
    }
    private void Start()
    {
        Creator.SetActive(false);
        Invoke("ShowDialog", 0.2f);
    }

    private void Update()
    {
        if (Creator.active == false && Quest["Sigward"] == 3 && Quest["Cat"] == 3 && Quest["Gal"] == 3 && Quest["Vik"] == 3)
        {
            Creator.SetActive(true);
            CreatorCanvas.SetActive(true);
            Creator.transform.position = new Vector3(-5.5f,8.35f,0);
        }
    }
    private void CreatorOff2()
    {
        Debug.Log("NoDelete:      " + dt.dm.counter.ToString());
        if (dt.dm.counter == 2) { Debug.Log("Delete"); Creator.SetActive(false); Invoke("CancelCreatorOff2", 1); }
    }
    private void CancelCreatorOff2()
    {
        CancelInvoke("CreatorOff2");
    }
    public void ShowDialog()
    {
        switch (d_ind)
        {
            case 0:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn0_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 0.01f);
                break;
            case 1:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn1_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 0.01f);
                break;
            case 2:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn2_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 0.01f);
                break;
            case 3:
                dt.Spawn3_TriggerDialogue();
                d_ind++;
                Save();
                break;
            case 4:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn4_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 0.01f);
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
        Quest["Sigward"] = data.Sigward;
        Quest["Cat"] = data.Cat;
        Quest["Gal"] = data.Gal;
        Quest["Vik"] = data.Vik;
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }
    private SaveData.Player GetSaveSnapshot()
    {
        var data = new SaveData.Player()
        {
            d_ind = this.d_ind,
            Sigward = this.Quest["Sigward"],
            Cat = this.Quest["Cat"],
            Gal = this.Quest["Gal"],
            Vik = this.Quest["Vik"],
        };
        return data;
    }
}
