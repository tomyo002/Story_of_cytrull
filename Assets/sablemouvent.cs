using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sablemouvent : MonoBehaviour
{
    public Collider2D col;
      private Transform target;
      private int val=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (val == 0)
            {
                StartCoroutine(enleveCol());
                val =1;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            col.enabled = true ;
            val = 0;
        }
    }
    public IEnumerator enleveCol()
    {
         yield return new WaitForSeconds(.5f);
         col.enabled = false;
    }
}
