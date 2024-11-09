using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private UIElement _menu, _settings;
    void Start()
    {
        _menu.Show();
    }
    public void OnClickPlay() 
    {
        _menu.Hide();
    }
    public void OnClickSettings() 
    {
        _settings.Show();
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickBack()
    {
        _settings.Hide();
    }
}
