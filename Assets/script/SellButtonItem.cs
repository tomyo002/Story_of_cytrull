
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
  public Text itemName;
  public Image itemImage;
  public Text itemPrix;

  public Item item;

  public void BuyItem()
  {
    Inventory inventory = Inventory.instance;
    if(inventory.coinsCount >= item.price)
    {
        inventory.content.Add(item);
        inventory.UpdateInventoryUi();
        inventory.coinsCount-= item.price;
        inventory.UpdateTextUI();
    }
  }
}
