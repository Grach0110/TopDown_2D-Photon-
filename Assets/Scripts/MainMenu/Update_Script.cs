using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Проверка обновления
/// </summary>
public class Update_Script : MonoBehaviour
{
    /// <summary>
    /// Кнопка обновления
    /// </summary>
    [SerializeField] Button buttonUpdate;
    /// <summary>
    /// Менеджер подключения
    /// </summary>
    [SerializeField] GameObject ManagerConnection;

    /// <summary>
    /// Вывод текущей версии
    /// </summary>
    [SerializeField] Text textCurrentVersion;
    /// <summary>
    /// Текущая версия разработки
    /// </summary>
    [SerializeField] string developmentVersion;

    private string stringText = "Current development Version ";

    private void Start()
    {
        textCurrentVersion.text = stringText + developmentVersion;
    }

    private void Update()
    {
        if (ManagerConnection.GetComponent<Connect_Lobby_Script>().isConnect)
        {
            buttonUpdate.interactable = true;
        }
        else
        {
            buttonUpdate.interactable = false;
        }
    }

    /// <summary>
    /// Переход в облако для обнавления
    /// </summary>
    public void ButtonCheckUpdate()
    {
        Application.OpenURL("https://yadi.sk/d/LC2b4BQw8hOzTw");
    }
}