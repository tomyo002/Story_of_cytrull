using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPosition : MonoBehaviour
{
    public float speed;
    public int CollisionDamage = 20;
    public Transform waypoints;
    public int speedDuration;
    private float valSpeed;
    public Animator animator;
    private Transform target;
    public bool IsFire;

    [SerializeField] private Transform weakSpotBoss;

    void Start()
    {
      target = waypoints;
      StartCoroutine(Fire());
      valSpeed=speed;   
    }

     void Update()
    {
        animator.SetBool("IsFire",IsFire);
         Vector3 dir= target.position - transform.position;
         dir.z=0;
         
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

    
    }
      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            PlayerHealth.TakeDamage(CollisionDamage);
        }
    }
    public  IEnumerator Fire()
    {
        yield return new WaitForSeconds(1);
        IsFire = false;
        yield return new WaitForSeconds(speedDuration);
        ShootFire();
        
         
    }
    public void ShootFire()
    {
        

        IsFire = true;
        transform.position=weakSpotBoss.position;
        StartCoroutine(Fire());
        
    }
}
