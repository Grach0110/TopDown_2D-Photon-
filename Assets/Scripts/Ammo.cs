using UnityEngine;

public class Ammo : MonoBehaviour
{
    /// <summary>
    /// Количество обойм для игрока
    /// </summary>
    [SerializeField] int clips;
    /// <summary>
    /// Количество пуль для игрока
    /// </summary>
    [SerializeField] int bullets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<FiringSystem>().UpdateAmmo(clips, bullets);

            Destroy(gameObject);
        }
    }
}