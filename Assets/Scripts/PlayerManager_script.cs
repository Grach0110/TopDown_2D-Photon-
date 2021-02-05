using System.IO;
using UnityEngine;

/// <summary>
/// Информация о игрока
/// </summary>
public class PlayerManager_script : MonoBehaviour
{
    string subPath = @"Assets/Resources";
    string nameFile = @"PlayerInfo.txt";

    /// <summary>
    /// Текущее имя игрока
    /// </summary>
    public string namePlayer;

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(subPath);

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileInfo fileInfo = new FileInfo(subPath + "/" + nameFile);

        if (!fileInfo.Exists)
        {
            fileInfo.Create();
        }

        StreamWriter streamWriter = new StreamWriter(subPath + "/" + nameFile, false, System.Text.Encoding.Default);
        streamWriter.WriteLineAsync(namePlayer);
        streamWriter.Close();
    }

    private void Load()
    {
        StreamReader streamReader = new StreamReader(subPath + "/" + nameFile);
        namePlayer = streamReader.ReadLine();
        streamReader.Close();
    }
}