using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakSpotBoss : MonoBehaviour
{
      public AudioClip sound;
    public GameObject objectToDestroy;
    private int LifeBoss=3;
     public float InvincibilityFlashDelay;
    public float InvicibilityTimeAfterHit = 3f;
     public SpriteRenderer graphics;

    
    public bool IsInvincible =false;
    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if(collision.CompareTag("Player"))
        {
              if(!IsInvincible)
              {
                AudioManager.instance.playClipAt(sound,transform.position);
                LifeBoss-=1;
                
                PickInvisible.instance.picLance();
                if(LifeBoss ==0)
                {
                    Destroy(objectToDestroy);
                }
                 IsInvincible =true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandInvincibilityDelay());
              }
            
        }   
        
    }
     public IEnumerator InvincibilityFlash()
    {
        while(IsInvincible)
        {
            
            graphics.color= new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
            graphics.color= new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
        }
    }
    public IEnumerator HandInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvicibilityTimeAfterHit);
        IsInvincible = false;
    }
}
