using UnityEngine;

public class ManagerScene_Script : MonoBehaviour
{
    [SerializeField] GameObject panelMainMenu;
    [SerializeField] GameObject panelOnLine;
    [SerializeField] GameObject panelSettings;

    private void Start()
    {
        panelMainMenu.SetActive(true);
        panelOnLine.SetActive(false);
        panelSettings.SetActive(false);
    }

    /// <summary>
    /// Выход из приложения
    /// </summary>
    public void ExitApp()
    {
        Application.Quit();
    }
}