using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem_script
{
    static string nameFile = "/PlayerInfo.txt";
    public static void SavePlayer(PlayerManager_script player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + nameFile;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerManager_script data = new PlayerManager_script(player);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerManager_script LoadPlayer()
    {
        string path = Application.persistentDataPath + nameFile;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerManager_script data = formatter.Deserialize(fileStream) as PlayerManager_script;
            fileStream.Close();
            return data;
        }
        else
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            return null;
        }
    }
}