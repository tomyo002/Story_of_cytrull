using System.Collections;
using UnityEngine;

public class DeathZones : MonoBehaviour
{
    private Transform playerspawn;
    public int CollisionDamage = 20;
    private Animator fadeSystem;

    private void Awake()
    {
        playerspawn= GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem= GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(replacePlayer(collision));
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            PlayerHealth.TakeDamage(CollisionDamage);
        }
    }
    private IEnumerator replacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position=playerspawn.position;
    }
}
