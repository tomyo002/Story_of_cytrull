using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reponseEnigmPorte : MonoBehaviour
{
      private Text interactUI;
    private bool isRange;
    public InputField inputR;
    public Button btn;
    public Button btnechap;
    public GameObject inp;
    public string reponse;
    public GameObject destroyed;
void start()
{
   
}
  void Update()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        
        if(isRange && Input.GetKeyDown(KeyCode.E))
        {
            inp.SetActive(true);
             playerHelth.instance.isEcrireReponse = true;
            PlayerMovement.instance.isEcrireReponse = true;

            
         btn.onClick.AddListener(GetsubmitName);
         btnechap.onClick.AddListener(echap);
    }

    
 
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isRange = true;
           
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isRange = false;
             inp.SetActive(false);
            playerHelth.instance.isEcrireReponse = false;
            PlayerMovement.instance.isEcrireReponse = false;
        
        }
    }
    private void GetsubmitName()
    {
        if(inputR.text == reponse)
        {
            Destroy(destroyed);
        }
        else{
            playerHelth.instance.TakeDamage(10);
        }
    }
    private void echap()
    {
        interactUI.enabled = false;
            isRange = false;
             inp.SetActive(false);
            playerHelth.instance.isEcrireReponse = false;
            PlayerMovement.instance.isEcrireReponse = false;
    }
}
