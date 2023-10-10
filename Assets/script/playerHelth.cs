using System.Collections;
using UnityEngine;


public class playerHelth : MonoBehaviour
{
    public int maxHealth ;
    public int currentHealth;
     public AudioClip sound;
     private int utiliser = 0;
    
    public float InvincibilityFlashDelay;
    public float InvicibilityTimeAfterHit = 3f;
    
    public bool IsInvincible =false;
    public helthBar healthborder;
    public SpriteRenderer graphics;

    public static playerHelth instance;
    public bool isEcrireReponse = false;
    private void Awake()
    {
        healthborder = GameObject.FindGameObjectWithTag("BarHealthUi").GetComponent<helthBar>();
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHelth dans la scene");
            return;
        }
        instance =this;
        
    }
    void Start()
    {
        currentHealth= maxHealth;
        healthborder.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(isEcrireReponse == false)
            {
                TakeDamageMaledition(100);
            }
           
        }

    }
    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) >= maxHealth)
        {
            currentHealth = maxHealth;
            healthborder.SetHealth(currentHealth);
        }else
        {
            currentHealth += amount;
            healthborder.SetHealth(currentHealth);
        }
     
        
    }
    public void TakeDamage(int damage)
    {
        if(!IsInvincible)
        {
            AudioManager.instance.playClipAt(sound,transform.position);
            currentHealth-=damage;
            healthborder.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            IsInvincible =true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandInvincibilityDelay());
        }
    }
    public void TakeDamageMaledition(int damage)
    {
        AudioManager.instance.playClipAt(sound,transform.position);
            currentHealth-=damage;
            healthborder.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

    }
    public void TakeDamagePlayer2(int damage)
    {
         currentHealth-=damage;
            healthborder.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
        
    }
    public void Die()
    {
        Debug.Log("Le joueur est mort");
        PlayerMovement.instance.enabled=false;
        PlayerMovement.instance.animator.SetTrigger("die");
        PlayerMovement.instance.Rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.Rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        Player2Die.instance.Dead();
    }
    public void respawn()
    {
        PlayerMovement.instance.enabled=true;
        PlayerMovement.instance.animator.SetTrigger("respawn");
        PlayerMovement.instance.Rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthborder.SetHealth(currentHealth);
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
    public void RingOfInvin()
    {
        IsInvincible =true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandInvincibilityDelay()); 
    }
    public void ViePLus()
    {
        if (utiliser ==0)
        {
              maxHealth =150;
            Start();
            utiliser +=1;

        }
           
    }
    public void VieMoins()
    {
        if (utiliser ==0)
        {
            currentHealth = 100;
            utiliser +=1;
        }
    }
    public IEnumerator mauditPyramide(float delay)
    {
    
         yield return new WaitForSeconds(delay);
         TakeDamageMaledition(1);
         StartCoroutine(mauditPyramide(delay));



    }
    public void elimMurHealth()
    {
        currentHealth -= 9999;
        if(currentHealth <= 0)
            {
                Die();
                return;
            }
    }
}
