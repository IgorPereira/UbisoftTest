using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession
{
	private static GameSession instance;
	public static GameSession Instance
	{
		get
		{
			if (instance == null)
				instance = new GameSession();

			return instance;
		}
	}

	private IDataSaver dataSaver;

    public ObservableProperty<string> TextValue { get; private set; }

	private GameSession()
	{
		TextValue = new ObservableProperty<string>("");

		dataSaver = new LocalDataSaver();
	}


	public void LoadSession()
	{
		dataSaver.LoadData(OnDataLoadedHandler);
	}

	public void SaveSession()
	{
		GameSaveData dataToSave = new GameSaveData(TextValue.Value);
		dataSaver.SaveData(dataToSave);
	}

	public void ResetSession(bool autosave)
	{
		TextValue.Value = "";

		if (autosave) SaveSession();
	}

	private void OnDataLoadedHandler(GameSaveData savedData)
	{
		TextValue.Value = savedData.Value;
	}
}