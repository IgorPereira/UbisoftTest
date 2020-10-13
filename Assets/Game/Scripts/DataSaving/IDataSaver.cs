using System;

namespace UbisoftTest
{
	public interface IDataSaver
	{
		void SaveData(GameSaveData saveData);
		void LoadData(Action<GameSaveData> OnLoadCompleted);
	}
}