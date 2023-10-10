
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButton;
    public Canvas[] WordButton;
    public int valWorld = 0;
   
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
         for(int i =0 ; i<levelButton.Length; i++)
         {
            if(i+1 > levelReached)
            {
                levelButton[i].interactable = false;
            }
            
         }
    }
    public void LoadLevelPass(string levelName)
    {
        SceneManager.LoadScene(levelName);

       
    }
    public void switchWorld()
    {
        WordButton[valWorld].enabled = true;
    }

    public void apresWorld()
    {
        WordButton[valWorld].enabled = false;
        valWorld +=1;
        switchWorld();
    }
    public void avantWorld()
    {
        WordButton[valWorld].enabled = false;
        valWorld -=1;
        switchWorld();
    }
}
