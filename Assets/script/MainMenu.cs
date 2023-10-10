using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;
    public string LevelMiniJeux1;
    public GameObject settingWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void StartGameMiniJeux()
    {
        SceneManager.LoadScene(LevelMiniJeux1);
    }
    public void Settings()
    {
        settingWindow.SetActive(true);
    }
    public void CloseSett()
    {
        settingWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credit()
    {
         SceneManager.LoadScene("credit");
    }
}
