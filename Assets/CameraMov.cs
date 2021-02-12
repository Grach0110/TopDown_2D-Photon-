using UnityEngine;

/// <summary>
/// Движение за игроком
/// </summary>
public class CameraMov : MonoBehaviour
{
    /// <summary>
    /// Игрок
    /// </summary>
    public Transform player;
    /// <summary>
    /// Позиция игрока
    /// </summary>
    private Vector3 playerVector;
    /// <summary>
    /// Скорость камеры
    /// </summary>
    private float speedCam = 5f;

    private void LateUpdate()
    {
        if (player != null)
        {
            playerVector = player.position;

            playerVector.z = -10;

            transform.position = Vector3.Lerp(transform.position, playerVector, speedCam * Time.deltaTime);
        }
        
    }
}