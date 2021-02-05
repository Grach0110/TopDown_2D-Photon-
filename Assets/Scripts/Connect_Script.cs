using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Подключение к сети
/// </summary>
public class Connect_Script : MonoBehaviour
{
    /// <summary>
    /// Текст текущего соединения
    /// </summary>
    [SerializeField] Text textConnect;

    /// <summary>
    /// Подключен к интернету
    /// </summary>
    public bool isConnect;

    void Update()
    {
        CheckInternet();
    }

    /// <summary>
    /// Проверка подключения к интеренту
    /// </summary>
    bool CheckInternet()
    {
        // Проверьте, не может ли устройство выйти в Интернет
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Change the Text
            textConnect.text = "Нет сети ";
            isConnect = false;
        }
        // Проверьте, может ли устройство выйти в Интернет через сеть передачи данных оператора
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            textConnect.text = "Reachable via carrier data network.";
            isConnect = true;
        }
        // Проверьте, может ли устройство выйти в Интернет через локальную сеть
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            textConnect.text = "Подключено ";
            isConnect = true;
        }
        return isConnect;
    }
}