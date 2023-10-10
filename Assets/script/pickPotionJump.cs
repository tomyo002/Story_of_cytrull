using System.Threading;
using UnityEngine;

public class pickPotionJump : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerMovement.instance.TakeJump();
            AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(gameObject);
        
            
        }
    }
}
