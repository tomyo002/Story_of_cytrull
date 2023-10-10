using System.Collections;
using UnityEngine;

public class MoveNuageT : MonoBehaviour
{
    public float speed;
     public Transform[] waypoints;

    private Transform target;

    private int desPoint;
    private bool isToxic = false;



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

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if(collision.CompareTag("Player"))
            {
                StartCoroutine(lanceToxic());
               isToxic = true;
            }

        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
            isToxic = false;
        }
    }
    public IEnumerator lanceToxic()
    {

         playerHelth.instance.TakeDamageMaledition(1);
        yield return new WaitForSeconds(.5f);
        if(isToxic)
        {
            StartCoroutine(lanceToxic());
        }
        
    }
   
}
