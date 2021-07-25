using UnityEngine;

/// <summary>
/// Передвижение персонажа
/// </summary>
public class PlayerMovementSystem : MonoBehaviour
{
    new
    /// <summary>
    /// Физическое тело
    /// </summary>
    Rigidbody2D rigidbody2D;
    /// <summary>
    /// Джостик
    /// </summary>
    [SerializeField] Joystick joystick;
    /// <summary>
    /// Движение
    /// </summary>
    private Vector2 movement;
    /// <summary>
    /// Скорость игрока
    /// </summary>
    private float speed = 5f;


    private void Start()
    {
        Camera.main.GetComponent<CameraMov>().player = gameObject.transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Передвижение
    /// </summary>
    private void Movement()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        float hAxis = joystick.Horizontal;
        float vAxis = joystick.Vertical;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;

        if (hAxis != 0 && vAxis != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
        }

        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }
}