using UnityEngine.SceneManagement;
using UnityEngine;

public class credit : MonoBehaviour
{

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            loadMainMenu();
        }
    } 
}
