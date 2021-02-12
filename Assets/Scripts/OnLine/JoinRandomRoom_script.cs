using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class JoinRandomRoom_script : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Кнопка случайной игры
    /// </summary>
    [SerializeField] Button buttonJoinRandonRooms;
    /// <summary>
    /// Название случайной игры
    /// </summary>
    private string nameRandomRoom = "testRoom";
    /// <summary>
    /// Количество игроков в комнате
    /// </summary>
    [SerializeField] byte playersRoom;

    public void OnClick_ButtonJoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();

        Debug.Log("Кнопка присоедениться к случайной игре");
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = playersRoom;

        PhotonNetwork.CreateRoom(nameRandomRoom, roomOptions, null);

        Debug.Log("Создание новой комнаты ");
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Не удалось присоедениться к случайной игре");
        CreateRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Комната создана, загрузка сцены с игрой ");
        PhotonNetwork.LoadLevel(1);
    }
}