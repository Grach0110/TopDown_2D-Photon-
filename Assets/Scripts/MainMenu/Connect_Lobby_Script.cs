using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Подключение к сети и к лобби
/// </summary>
public class Connect_Lobby_Script : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Текст текущего соединения
    /// </summary>
    [SerializeField] Text textConnect;
    /// <summary>
    /// Кнопка сеть
    /// </summary>
    [SerializeField] Button buttonOnline;

    /// <summary>
    /// Подключен к интернету
    /// </summary>
    public bool isConnect;

    /// <summary>
    /// Текущая версия Photon
    /// </summary>
    public string currentVersionPhoton;

    /// <summary>
    /// Данные игрока
    /// </summary>
    [SerializeField] GameObject playerManager;

    void Update()
    {
        CheckInternet();
    }

    /// <summary>
    /// Проверка подключения к интеренту
    /// </summary>
    bool CheckInternet()
    {
        // Проверка, не может ли устройство выйти в Интернет
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            textConnect.text = "Нет сети ";
            isConnect = false;
            buttonOnline.interactable = false;
        }
        // Проверка, может ли устройство выйти в Интернет через сеть передачи данных оператора
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            textConnect.text = "Подключено ";
            isConnect = true;
            //buttonOnline.interactable = true;
        }
        // Проверка, может ли устройство выйти в Интернет через локальную сеть
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            textConnect.text = "Подключено ";
            isConnect = true;
            //buttonOnline.interactable = true;
        }
        return isConnect;
    }

    /// <summary>
    /// Кнопка подключение к Phohon кнопка на главном меню "сеть"
    /// </summary>
    public void Click_Button_ConnectToPhoton_Lobby()
    {
        Debug.Log("Кнопка Подключения к фотон и лобби ");
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.JoinLobby())
            {
                Debug.Log("Уже в лобби ");
            }
            else
            {
                PhotonNetwork.JoinLobby();
                Debug.Log("Подключение к лобби ");
            }
        }
        else
        {
            PhotonNetwork.GameVersion = currentVersionPhoton;
            PhotonNetwork.NickName = playerManager.GetComponent<Player>().name;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }

    /// <summary>
    /// Кнопка отключения от лобби и от сервера
    /// </summary>
    public void Click_Button_Disconnect_Photon_Lobby()
    {
        PhotonNetwork.LeaveLobby();
        Debug.Log("Кнопка выйти из лобби ");
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Подключен к мастеру ");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Подключен к лобби ");
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Вышел из лобби ");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Отключен от серврера " + cause.ToString());
    }
}