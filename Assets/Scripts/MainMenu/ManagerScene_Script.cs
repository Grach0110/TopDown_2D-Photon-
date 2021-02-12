using UnityEngine;

public class ManagerScene_Script : MonoBehaviour
{
    [SerializeField] GameObject managerConnect;

    [SerializeField] GameObject panelMainMenu;
    [SerializeField] GameObject panelOnLineLobby;
    [SerializeField] GameObject panelCreateRoom;
    [SerializeField] GameObject panelCurrentRoom;
    [SerializeField] GameObject panelSettings;

    bool connect;

    private void Start()
    {
        panelMainMenu.SetActive(true);
        panelOnLineLobby.SetActive(false);
        panelCreateRoom.SetActive(false);
        panelCurrentRoom.SetActive(false);
        panelSettings.SetActive(false);
    }

    public void Update()
    {
        connect = managerConnect.GetComponent<Connect_Lobby_Script>().isConnect;
        InternetOn(connect);
    }

    public void InternetOn(bool on)
    {
        if (on)
        {

        }
        else
        {
            panelMainMenu.SetActive(true);
            panelOnLineLobby.SetActive(false);
            panelCreateRoom.SetActive(false);
            panelCurrentRoom.SetActive(false);
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}