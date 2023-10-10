using UnityEngine.UI;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public bool IsInRange;
    public Item[] itemsToSell;

    public string PnjName;

    private Text interactUI;

    private void Awake()
    {
          interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    void Update()
    {
        if(IsInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemsToSell, PnjName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled =true;
            IsInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsInRange = false;
            interactUI.enabled =false;
            ShopManager.instance.CloseShop();
        }
    }
}
