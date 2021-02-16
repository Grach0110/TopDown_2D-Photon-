using UnityEngine;

/// <summary>
/// Пуля
/// </summary>
public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody;
    /// <summary>
    /// Скорость пули
    /// </summary>
    private float speedBullet = 20f;

    public void Update()
    {
        //rigidbody.velocity += new Vector2(0,1) * speedBullet * Time.fixedDeltaTime;
        gameObject.transform.position += gameObject.transform.up * speedBullet * Time.deltaTime;

        Destroy(gameObject, 5f);
    }
}