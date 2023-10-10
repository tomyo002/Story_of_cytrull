using UnityEngine.UI;
using UnityEngine;

public class inventoryKey : MonoBehaviour
{
    public Image nombrekey;
    public int compterKey =0 ;
    public static inventoryKey instance;
  
  private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de InventoryKey dans la scene");
        return;
    }
    instance =this;
  }

    void Update()
    {
        if (compterKey ==0)
        {
            nombrekey.enabled = false;
        }else
        {
            nombrekey.enabled = true;
        }

    }
    public void AddKey(int Key)
   {
        compterKey += Key;
        
   }
   public void removeKey(int Key)
   {
        compterKey -= Key;
   }
   public void resetKey()
   {
        compterKey = 0;
   }
}
