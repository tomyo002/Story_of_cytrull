using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoixFamilier : MonoBehaviour
{
     public Text interact;
     public bool isInRangeEgg;
     public GameObject VenteEgg;
     public int ValEgg;
     void Update()
    {
         interact = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        if(isInRangeEgg == true)
        {
             if(Input.GetKeyDown(KeyCode.E))
             {
                familierSet.instance.jeTaiChoisi(ValEgg);
                Destroy(VenteEgg);
             }
        }
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = true;  
             isInRangeEgg = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = false;
             isInRangeEgg = false;
        }
    }
   
}
