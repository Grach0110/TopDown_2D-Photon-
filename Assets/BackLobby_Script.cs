using Photon.Pun;

/// <summary>
/// Выход в лобби
/// </summary>
public class BackLobby_Script : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Кнопка выхода из комнатвыs
    /// </summary>
    public void OnClick_BackLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
    }

}