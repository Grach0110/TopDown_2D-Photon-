using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string name;

    public Text textWelcom;

    private void Awake()
    {
        LoadPlayer();
        textWelcom.text = "С возвращением\n" + name + " !!!!";
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        name = data.name;
    }
}