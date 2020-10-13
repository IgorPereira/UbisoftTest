using System.IO;
using UnityEngine;

namespace UbisoftTest
{
	public class LocalDataSaver : IDataSaver
	{
		private const string folderName = "GameSaveData";
		private const string filename = "SaveData.txt";

		private readonly string directoryPath;
		private readonly string fullPath;

		public LocalDataSaver()
		{
			directoryPath = Path.Combine(Application.persistentDataPath, folderName);
			fullPath = Path.Combine(Application.persistentDataPath, folderName, filename);
		}

		public void SaveData(GameSaveData saveData)
		{
			CreateDirectoryIfNeeded();

			string fileContents = JsonUtility.ToJson(saveData);

			File.WriteAllText(fullPath, fileContents);
		}

		public void LoadData(System.Action<GameSaveData> OnLoadCompleted)
		{
			CreateDirectoryIfNeeded();

			string fileContents = null;

			if (File.Exists(fullPath))
				fileContents = File.ReadAllText(fullPath);

			GameSaveData saveData;
			if (!string.IsNullOrEmpty(fileContents))
				saveData = JsonUtility.FromJson<GameSaveData>(fileContents);
			else
				saveData = new GameSaveData() { Value = "" };

			OnLoadCompleted?.Invoke(saveData);
		}

		private void CreateDirectoryIfNeeded()
		{
			if (!Directory.Exists(directoryPath))
				Directory.CreateDirectory(directoryPath);
		}
	}
}