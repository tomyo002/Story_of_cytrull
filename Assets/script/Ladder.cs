
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMove;
    public BoxCollider2D topCollider;
    public Text interact;


    

    // Update is called once per frame
    void Update()
    {
        
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interact = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        
        if(isInRange && playerMove.isClimbing &&  Input.GetKeyDown(KeyCode.E) )
        {
            playerMove.isClimbing = false;
            topCollider.isTrigger = false;
            return;

        }
        if(isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            playerMove.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMove.isClimbing = false;
            topCollider.isTrigger = false;
            interact.enabled = false;
        }
    }
   
}
