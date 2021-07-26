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
        
    }

    public void LoadPlayer()
    {

    }
}