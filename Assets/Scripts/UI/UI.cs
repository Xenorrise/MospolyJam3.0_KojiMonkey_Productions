using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(1);
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
