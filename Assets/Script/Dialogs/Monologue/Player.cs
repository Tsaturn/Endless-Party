using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DialogueTrigger dt;
    public int d_ind = 0;
    public GameObject Creator;

    //0 - ������ �� �������, 1 - ����� ��������, 2 - ����� ��������, 3 - ������ �� ��������� ���� ������
    public Dictionary<string, int> Quest = new Dictionary<string, int>();
    private const string saveKey = "PlayerSave";
    public void Awake()
    {
        Load();
        if (!Quest.ContainsKey("Sigward"))
            Quest["Sigward"] = 0;
    }
    private void Start()
    {
        Invoke("ShowDialog", 0f);
    }
    private void CreatorOff2()
    {
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
                InvokeRepeating("CreatorOff2", 0, 1);
                break;
            case 1:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn1_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 1);
                break;
            case 2:
                Creator.SetActive(true);
                Creator.transform.position = new Vector3(-5, -1, 0);
                dt.Spawn2_TriggerDialogue();
                d_ind++;
                Save();
                InvokeRepeating("CreatorOff2", 0, 1);
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
                InvokeRepeating("CreatorOff2", 0, 1);
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
        };
        return data;
    }
}
