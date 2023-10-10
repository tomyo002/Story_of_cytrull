using UnityEngine.UI;
using UnityEngine;

public class openChest : MonoBehaviour
{
    private Text interactUI;
    private bool isRange;
    public Animator animator;
    public int CoinsAdd;
    public AudioClip Sound;
    
    void Update()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        if(Input.GetKeyDown(KeyCode.E) && isRange)
        {
            OpenChestAnim();
        }
    }
    void OpenChestAnim()
    {
        animator.SetTrigger("open");
        Inventory.instance.Addcoins(CoinsAdd);
        
        AudioManager.instance.playClipAt(Sound,transform.position);
        GetComponent<BoxCollider2D>().enabled = false;  
        interactUI.enabled = false;
        isRange = false;   
        for(int i = 0; i < CoinsAdd; i++) 
        {
            currentSceneManager.instance.coinspickedupcount++;
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
