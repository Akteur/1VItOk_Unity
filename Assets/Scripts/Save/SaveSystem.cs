using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Directory.CreateDirectory(Application.dataPath + "/Save");
        if(playerData.playerName != null)
        {
            string path = Application.dataPath + "/Save/" + playerData.playerName + ".save";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            SaveData saveData = new SaveData(playerData);

            formatter.Serialize(fileStream, saveData);
            fileStream.Close();
        }
        else
        {

        }
    }
    public static SaveData Load()
    {
        string path;
        if (GameManager.instance.GetPlayerName() != null)
        {
            path = Application.dataPath + "/Save/" + GameManager.instance.GetPlayerName() + ".save";
        }
        else
        {
            path = null;
        }
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(fileStream) as SaveData;
            fileStream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}