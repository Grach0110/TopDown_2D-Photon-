using System.IO;
using UnityEngine;

/// <summary>
/// Информация о игрока
/// </summary>
public class PlayerManager_script : MonoBehaviour
{
    /// <summary>
    /// Путь к папке
    /// </summary>
    string subPath = @"Assets/Resources";
    /// <summary>
    /// Название файла
    /// </summary>
    string nameFile = @"PlayerInfo.txt";

    /// <summary>
    /// Текущее имя игрока
    /// </summary>
    private string namePlayer;

    public string NamePlayer
    {
        get
        {
            return namePlayer;
        }
        set
        {
            namePlayer = value;
        }
    }

    private void Awake()
    {
        Load();
    }

    /// <summary>
    /// Сохранение
    /// </summary>
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

        StreamWriter streamWriter = new StreamWriter(subPath + "/" + nameFile, false, System.Text.Encoding.UTF8);
        streamWriter.WriteLineAsync(namePlayer);
        streamWriter.Close();
        Debug.Log("Сохранение ");
    }

    /// <summary>
    /// Загрузка
    /// </summary>
    private void Load()
    {
        StreamReader streamReader = new StreamReader(subPath + "/" + nameFile,System.Text.Encoding.UTF8);
        namePlayer = streamReader.ReadLine();
        streamReader.Close();
        Debug.Log("Загрузка ");
    }
}