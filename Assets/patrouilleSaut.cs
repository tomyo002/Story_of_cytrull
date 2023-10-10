using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrouilleSaut : MonoBehaviour
{
    public int CollisionDamage = 20;
      private Transform target;
    public Collider2D col;
      public Animator anim;
      private int valAnim =0 ; 
    public Transform[] waypoints;
    private int desPoint;
    public float speed;
    public float temps;

    // Start is called before the first frame update

        
    void Start()
    {
      target = waypoints[0];  
    }



    // Update is called once per frame
    void Update()
    {
        if(valAnim ==2)
        {
             Vector3 dir= target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
            if(Vector3.Distance(transform.position,target.position) < 0.3f)
        {
            desPoint = (desPoint+1) % waypoints.Length;
            target = waypoints[desPoint];
            if (desPoint ==0)
            {
                valAnim =0;
            }
            
        }
           
        }
        
   

        if( valAnim ==0)
        {
            anim.enabled =true;  
            col.enabled = true;
            StartCoroutine(jump(temps));
           valAnim = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            PlayerHealth.TakeDamage(CollisionDamage);
        }
         if(collision.transform.CompareTag("Player2"))
        {
            playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
            Player2Die.instance.TakeDamage2(CollisionDamage);
        }
   
    }
    public IEnumerator jump( float temps)
    {
        yield return new WaitForSeconds(temps);
        col.enabled = false;
         anim.enabled = false;
        valAnim =2;
    }

}
