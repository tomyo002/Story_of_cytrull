using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickInvisible : MonoBehaviour
{
    public GameObject pic;
     public float speed;
    public float Duration;
    public BoxCollider2D picCollider;
    public static PickInvisible instance;
    public int CollisionDamage = 20;
    public Transform waypoints;
    private Transform target;
     [SerializeField] private Transform weakSpotBoss;

     private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de PickInvisible dans la scene");
        return;
    }
    instance =this;
  }
    // Start is called before the first frame update
    void Start()
    {
         target = waypoints;
        pic.gameObject.GetComponent<Renderer>().enabled = false;
        picCollider.isTrigger = true;
    }
    void Update()
    {
         Vector3 dir= target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(pic.gameObject.GetComponent<Renderer>().enabled == true)
        {
            if(collision.transform.CompareTag("Player"))
            {
                playerHelth PlayerHealth = collision.transform.GetComponent<playerHelth>();
                PlayerHealth.TakeDamage(CollisionDamage);
            }
        }
       
    }
    public void picLance()
    {
        StartCoroutine(picSpawn());
    }
    public IEnumerator picSpawn()
    {
        yield return new WaitForSeconds(Duration);
        pic.gameObject.GetComponent<Renderer>().enabled= true;
        picCollider.isTrigger = false;
         transform.position=weakSpotBoss.position;
        yield return new WaitForSeconds(10);
        pic.gameObject.GetComponent<Renderer>().enabled = false;
        picCollider.isTrigger = true;
    }
}
