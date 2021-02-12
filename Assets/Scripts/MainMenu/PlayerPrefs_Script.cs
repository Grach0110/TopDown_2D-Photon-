using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefs_Script : MonoBehaviour
{
    /// <summary>
    /// Поле для вода имени
    /// </summary>
    [SerializeField] InputField inputFieldNamePlayer;
    /// <summary>
    /// Кнопка подтверждения
    /// </summary>
    [SerializeField] Button buttonSelectNamePlayer;
    /// <summary>
    /// Управление игроком
    /// </summary>
    [SerializeField] GameObject managerPlayer;

    private void Start()
    {
        GetName();
    }

    /// <summary>
    /// Поле ввода имени
    /// </summary>
    /// <param name="value"> Введенное имя игрока </param>
    public void SetName(string value)
    {
        if (value.Length > 2 && value.Length < 12)
        {
            buttonSelectNamePlayer.interactable = true;
        }
        else
        {
            buttonSelectNamePlayer.interactable = false;
        }
    }

    /// <summary>
    /// Подтверждение выбора имени
    /// </summary>
    public void SelectNamePlayer()
    {
        PlayerPrefs.SetString("Name", inputFieldNamePlayer.text);
        buttonSelectNamePlayer.interactable = false;

        managerPlayer.GetComponent<PlayerManager_script>().namePlayer = inputFieldNamePlayer.text;
        managerPlayer.GetComponent<PlayerManager_script>().Save();
        Debug.Log("Выбор нового имени игрока ");
    }

    private void GetName()
    {
        inputFieldNamePlayer.text = PlayerPrefs.GetString("Name");
        Debug.Log("Имя игрока установленно ");
    }
}