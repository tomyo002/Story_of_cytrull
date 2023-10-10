using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class enigmePhinx : MonoBehaviour
{
     private Text interactUI;
    private bool isRange;
    private string user = System.Environment.UserName;

   
    void Update()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        
        if(isRange && Input.GetKeyDown(KeyCode.E))
        {
           string fileName = @"C:\Users\"+user+@"\OneDrive\Bureau\588410.txt";  
           string fileName2 = @"C:\Users\Pc\Desktop\588410.txt";  
   
                if (File.Exists(fileName))    
                {    
                    File.Delete(fileName);    
                }    
                
            File.Create(fileName);
                if (File.Exists(fileName2))
                {
                    File.Delete(fileName2);
                }
            File.Create(fileName2);

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
        }
    }

}
