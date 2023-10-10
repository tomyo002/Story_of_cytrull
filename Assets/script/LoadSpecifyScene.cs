using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpecifyScene : MonoBehaviour
{
    public string SceneName;
    public Animator fadeSystem;
    public int Levelwap;
    public Text interact;
 
    public bool isInRangeDoorScene;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        interact = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
       
    }
    private void Update()
    {
         if( Input.GetKeyDown(KeyCode.E) && isInRangeDoorScene == true)
            {
                 currentSceneManager.instance.vallevel(Levelwap);
                StartCoroutine(loadNextScene());
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interact.enabled = true;
            isInRangeDoorScene = true; 
           
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interact.enabled = false;
         isInRangeDoorScene = false;
    }
    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
         interact.enabled = false;
         isInRangeDoorScene = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneName);
        
       
    }

        
 
}
