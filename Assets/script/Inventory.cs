using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  public int coinsCount;
  public Text coinsCountText;
  public static Inventory instance;
  public PlayerEffect playEffect;
  public Image itemUiImage;
  public Text ItemNameUI;
  public Sprite EmptyImage;
  public AudioClip sound;
  
  public List<Item> content = new List<Item>();
  public int contentCurrentINdex = 0;

  private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scene");
        return;
    }
    instance =this;
  }
  public void Start()
  {
    UpdateInventoryUi();
  }
  public void ConsumeItem()
  {
    if(content.Count ==0)
    {
      return;
    }
    Item currentItem =content[contentCurrentINdex];
    playerHelth.instance.HealPlayer(currentItem.hpGiven);
    if(currentItem.invincibilityItem == true)
    {
      playerHelth.instance.RingOfInvin();
    }
    if(currentItem.inverse == true)
    {
      playEffect.inverse(currentItem.inverseDuration);
    }
    playEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
    content.Remove(currentItem);
    GetNextItem();
    if(currentItem.isDoublePiece == true)
    {
      AudioManager.instance.playClipAt(sound,transform.position);
       coinsCount *= 2;
      UpdateTextUI();
    }
  }
  public void GetNextItem()
  {
    if(content.Count ==0)
    {
      UpdateInventoryUi();
      return;
    }
    contentCurrentINdex++;
    if(contentCurrentINdex> content.Count -1)
    {
      contentCurrentINdex =0;
    }
    UpdateInventoryUi();
  }
  public void GetPreviousItem()
  {
    if(content.Count ==0)
    {
      return;
    }
    contentCurrentINdex--;
    if (contentCurrentINdex < 0)
    {
      contentCurrentINdex = content.Count -1;
    }
    UpdateInventoryUi();
  }
  public void UpdateInventoryUi()
  {
    if(content.Count!= 0)
    {
         itemUiImage.sprite = content[contentCurrentINdex].image;
         ItemNameUI.text = content[contentCurrentINdex].name;
    }else
    {
      itemUiImage.sprite = EmptyImage;
      ItemNameUI.text = "vide";
    }
 
  }
  public void Addcoins(int count)
  {
      coinsCount += count;
      UpdateTextUI();
  }
  public void RemoveCoins(int count)
  {
    coinsCount -= count;
    UpdateTextUI();
  }
  public void UpdateTextUI()
  {
    coinsCountText.text =coinsCount.ToString();
  }
}

