using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuMN : MonoBehaviour
{
   
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
  
        SceneManager.LoadScene("MainMenu");
    }
}
