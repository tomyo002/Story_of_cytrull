using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUi;

    public static GameOverManager instance;
  
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scene");
            return;
        }
        instance =this;
    }
    
    public void OnPlayerDeath()
    {

        gameOverUi.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(currentSceneManager.instance.coinspickedupcount);
        inventoryKey.instance.resetKey();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUi.SetActive(false);
        playerHelth.instance.respawn();
    }

    public void MainMenuButton()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
