using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Die : MonoBehaviour
{
     public float InvincibilityFlashDelay;
    public float InvicibilityTimeAfterHit = 3f;
     public SpriteRenderer graphics;
     public AudioClip sound;
    
    public bool IsInvincible =false;
     public static Player2Die instance;
  
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Player2Die dans la scene");
            return;
        }
        instance =this;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
     public void TakeDamage2(int damage)
    {
        if(!IsInvincible)
        {
            playerHelth.instance.TakeDamagePlayer2(damage);
            AudioManager.instance.playClipAt(sound,transform.position);
            IsInvincible =true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandInvincibilityDelay());
        }
    }
     public IEnumerator InvincibilityFlash()
    {
        while(IsInvincible)
        {
            graphics.color= new Color(0f,0f,0f,0f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
            graphics.color= new Color(0f,0f,0f,1f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
        }
    }
    public IEnumerator HandInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvicibilityTimeAfterHit);
        IsInvincible = false;
    }
}
