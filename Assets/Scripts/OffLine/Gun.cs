using UnityEngine;

/// <summary>
/// Оружие
/// </summary>
public class Gun : MonoBehaviour
{
    /// <summary>
    /// Пистолет
    /// </summary>
    public bool isPistol;
    /// <summary>
    /// Глушитель
    /// </summary>
    public bool isSilencer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isPistol)
            {
                collision.gameObject.GetComponent<FiringSystem>().pistol = true;
                Debug.Log("1");
            }
            if(isPistol && isSilencer)
            {
                collision.gameObject.GetComponent<FiringSystem>().pistol = true;
                collision.gameObject.GetComponent<FiringSystem>().silencer = true;
                Debug.Log("2");
            }
            if(isSilencer)
            {
                collision.gameObject.GetComponent<FiringSystem>().silencer = true;
                Debug.Log("3");
            }

            collision.gameObject.GetComponent<FiringSystem>().updateSprite = true;
            Destroy(gameObject);
        }
    }
}