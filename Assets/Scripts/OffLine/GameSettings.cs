using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Игровые настройки
/// </summary>
public class GameSettings : MonoBehaviour
{
    /// <summary>
    /// Текущий уровень
    /// </summary>
    int currentLvl;

    public void Start()
    {
        currentLvl = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Пауза
    /// </summary>
    public void PauseOn()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Обычная скорость
    /// </summary>
    public void PauseOff()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Перезапуск уровня
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(currentLvl);
    }

    /// <summary>
    /// Выход в главное меню
    /// </summary>
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}