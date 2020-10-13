using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataSaver
{
    void SaveData(GameSaveData saveData);
    void LoadData(Action<GameSaveData> OnLoadCompleted);
}