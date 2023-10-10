using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{

     public Animator fadeSystem;
     public static EndGame instance;
       private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de EndGame dans la scene");
        return;
    }
    instance =this;
    fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    
  }
    
    public void End()
    {
         StartCoroutine(loadNextScene());
    }
     public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("credit");     
       
    }
    public IEnumerator suivant(int valSuivant, string name)
    {
        currentSceneManager.instance.vallevel(valSuivant);
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name); 
    }
}
