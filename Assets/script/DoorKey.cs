using UnityEngine.UI;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public Text interact;
    public AudioClip sound;
    public bool isInRangeDoor;
    
       void Update()
    {
         interact = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        if(isInRangeDoor == true)
        {
             if(inventoryKey.instance.compterKey >= 1 && Input.GetKeyDown(KeyCode.E))
            {
                inventoryKey.instance.removeKey(1);
                AudioManager.instance.playClipAt(sound,transform.position);
                Destroy(gameObject);
            }
        }
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = true;  
             isInRangeDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = false;
             isInRangeDoor = false;
        }
    }
   
}
