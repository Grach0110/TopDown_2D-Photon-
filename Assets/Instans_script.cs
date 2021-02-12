using UnityEngine;
using Photon.Pun;

/// <summary>
/// Появление 
/// </summary>
public class Instans_script : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Ссылка на префаб
    /// </summary>
    public GameObject playerPrefab;

    private void Awake()
    {
        PhotonNetwork.Instantiate( playerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity );
    }
}