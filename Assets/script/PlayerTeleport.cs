using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleport : MonoBehaviour
{
    public Text interact;

    private GameObject currentTeleporter;


    // Start is called before the first frame update
    void Update()
    {
        interact = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
           {
                transform.position=currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
           } 
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            interact.enabled = true;
            currentTeleporter=collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = null;
            interact.enabled = false;
        }
      
           
    }
   
    

}
