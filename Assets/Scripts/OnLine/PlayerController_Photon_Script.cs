using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Управление персонажом
/// </summary>
public class PlayerController_Photon_Script : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Фотон
    /// </summary>
    private PhotonView photonView;
    /// <summary>
    /// Твердое тело
    /// </summary>
    Rigidbody2D rigidbody2D;
    /// <summary>
    /// Джостик
    /// </summary>
    public Joystick joystick;
    /// <summary>
    /// Движение
    /// </summary>
    Vector2 move;
    /// <summary>
    /// Скорость движения
    /// </summary>
    private float speed = 5f;
    /// <summary>
    /// Имя персонажа
    /// </summary>
    public Text textName;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            return;
        }
        else
        {
            GetName();
            Camera.main.GetComponent<CameraMov>().player = gameObject.transform;
            rigidbody2D = GetComponent<Rigidbody2D>();
            joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        Move();
    }

    /// <summary>
    /// Движение
    /// </summary>
    private void Move()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        float hAxis = joystick.Horizontal;
        float vAxis = joystick.Vertical;
        float zAxis = Mathf.Atan2(hAxis,vAxis) * Mathf.Rad2Deg;

        if (hAxis != 0 && vAxis != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
        }

        rigidbody2D.MovePosition(rigidbody2D.position + move * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Получить имя
    /// </summary>
    public void GetName()
    {
        textName.text = photonView.Owner.NickName;
        Debug.Log(textName.text + " - 1");
        textName.text = PhotonNetwork.NickName;
        Debug.Log(textName.text + " - 2");
    }
}