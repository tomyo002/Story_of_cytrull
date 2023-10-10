using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruCrystall : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip sound;
    public int variableNiveauSuivant;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if(collision.CompareTag("Player"))
        {
                AudioManager.instance.playClipAt(sound,transform.position);
                StartCoroutine(  EndGame.instance.suivant(variableNiveauSuivant, sceneName));
                StartCoroutine(destroyObjet());
               
                
        }  
       
        
    }
     public IEnumerator destroyObjet()
        {
            yield return new WaitForSeconds(.05f);
             Destroy(objectToDestroy);
        }  
   
}
