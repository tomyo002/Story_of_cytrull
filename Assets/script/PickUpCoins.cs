
using UnityEngine;

public class PickUpCoins : MonoBehaviour
{

     public AudioClip sound;

   private void OnTriggerEnter2D(Collider2D collision)
   {
     
       if(collision.CompareTag("Player"))
       {
            Inventory.instance.Addcoins(1);
            AudioManager.instance.playClipAt(sound,transform.position);
            currentSceneManager.instance.coinspickedupcount++;
            Destroy(gameObject);
       }
        if(collision.CompareTag("Player2"))
       {
          AudioManager.instance.playClipAt(sound,transform.position);
          Inventory.instance.Addcoins(1);
          currentSceneManager.instance.coinspickedupcount++;
          Destroy(gameObject);
       }
   }
}
