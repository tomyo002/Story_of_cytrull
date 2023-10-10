
using UnityEngine;

public class PickPotionLife : MonoBehaviour
{
    public AudioClip sound;
    public int HealthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHelth.instance.HealPlayer(HealthPoints);
             AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Player2"))
        {
            playerHelth.instance.HealPlayer(HealthPoints);
             AudioManager.instance.playClipAt(sound,transform.position);
            Destroy(gameObject);
        }
    }
}
