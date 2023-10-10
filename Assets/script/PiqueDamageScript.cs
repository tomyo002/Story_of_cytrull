
using UnityEngine;

public class PiqueDamageScript : MonoBehaviour
{
    public int CollisionDamage = 20;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            PlayerHealth.TakeDamage(CollisionDamage);
        }
        if(collision.CompareTag("Player2"))
        {
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            Player2Die.instance.TakeDamage2(CollisionDamage);
        }
    }
}
