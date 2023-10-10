using UnityEngine.UI;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isRange;
    public Item item;
    public AudioClip Sound;
    
    void Update()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        if(Input.GetKeyDown(KeyCode.E) && isRange)
        {
            TakeItem();
        }
    }
    void TakeItem()
    {
       Inventory.instance.content.Add(item);
       Inventory.instance.UpdateInventoryUi();
       AudioManager.instance.playClipAt(Sound, transform.position);
       interactUI.enabled = false;
       Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isRange = true;
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isRange = false;
        }
    }
  
}
