
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip sound;
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(objectToDestroy);
        }
         if(collision.CompareTag("Player2"))
        {
            AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(objectToDestroy);
        }
    }
}
