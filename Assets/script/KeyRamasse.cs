using UnityEngine.UI;
using UnityEngine;

public class KeyRamasse : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       {
            inventoryKey.instance.AddKey(1);
            AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(gameObject);
       }
       
   }
}   
