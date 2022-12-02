using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// Все полученные игроком концовки
/// </summary>
public class Endings : MonoBehaviour
{
    // полученные концовки
    private bool[] achieved;

    // Конструктор
    public Endings() => achieved = new bool[0];

    // Добавить полученную концовку
    public void AddEnding(int code)
    {
        if (achieved.Length <= code)
            Array.Resize(ref achieved, code - 1);
        achieved[code - 1] = true;
        Save();
    }

    // Ключ, по которому лежат данные
    private const string saveKey = "endings_save";

    // Сохранение
    private void Save() => SaveManager.Save(saveKey, GetSaveSnapshot());

    private SaveData.Endings GetSaveSnapshot()
    {
        var data = new SaveData.Endings() { _achieved = achieved };
        return data;
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData.Endings>(saveKey);
        achieved = data._achieved;
    }

    private void Start() => Load();
}