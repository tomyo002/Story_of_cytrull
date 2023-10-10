using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
     public static ShopManager instance;
     public Animator animator;
     public Text PnjNameText;
     public GameObject sellButtonPrefab;
     public Transform sellButtonParent;
        private void Awake()
        {
            if(instance != null)
            {
                Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scene");
                return;
            }
            instance =this;

            
        }
    public void OpenShop(Item[] item, string pnjName)
    {
        PnjNameText.text = pnjName;
        UpdatetoSell(item);
        animator.SetBool("IsOpen",true);
       
    }
    void UpdatetoSell(Item[] item)
    {
        for (int i=0; i<sellButtonParent.childCount;i++)
        {
            Destroy(sellButtonParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < item.Length; i++)
        {
            GameObject button=Instantiate(sellButtonPrefab, sellButtonParent);
            SellButtonItem buttonScript =button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text =item[i].name;
            buttonScript.itemImage.sprite = item[i].image;
            buttonScript.itemPrix.text =item[i].price.ToString();
            buttonScript.item = item[i];
            button.GetComponent<Button>().onClick.AddListener(delegate{buttonScript.BuyItem(); } );
        }
    }
    public void CloseShop()
    {
      animator.SetBool("IsOpen",false);
    }
}
