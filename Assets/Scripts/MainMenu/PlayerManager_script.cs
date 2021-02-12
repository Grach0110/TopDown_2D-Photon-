using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Информация о игрока
/// </summary>
public class PlayerManager_script : MonoBehaviour
{
    public Text textName;
    public Text textPaht;
    string nameFile = "/PlayerInfo.txt";

    public string namePlayer;

    public int level;

    public PlayerManager_script (PlayerManager_script player)
    {
        namePlayer = player.namePlayer;
        level = player.level;
    }

    private void Start()
    {
        //Load();
        textName.text = "С возвращением " + namePlayer;
        textPaht.text = Application.persistentDataPath + nameFile;
    }

    public void Save()
    {
        SaveSystem_script.SavePlayer(this);
    }

    public void Load()
    {
       PlayerManager_script data = SaveSystem_script.LoadPlayer();

        namePlayer = data.namePlayer;
        level = data.level;
    }
}