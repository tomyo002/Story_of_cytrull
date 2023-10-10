
using UnityEngine;

public class patrouilleEnnemy : MonoBehaviour

{
    public float speed;
    public int CollisionDamage = 20;
    public Transform[] waypoints;

    private Transform target;

    private int desPoint;


    public SpriteRenderer graphics;

    void Start()
    {
      target = waypoints[0];  
    }


    void Update()
    {
        Vector3 dir= target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        // si l'ennemi est quasiment arriver a sa destination
        if(Vector3.Distance(transform.position,target.position) < 0.3f)
        {
            desPoint = (desPoint+1) % waypoints.Length;
            target = waypoints[desPoint];
            graphics.flipX =!graphics.flipX;
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
}
