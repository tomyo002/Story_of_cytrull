using System.Linq;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    
    public static  LoadAndSaveData instance;
  
    private void Awake()
    {
        
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de  LoadAndSaveData dans la scene");
            return;
        }
        instance =this;
    }
    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount",0);
        Inventory.instance.UpdateTextUI();
        familierSet.instance.idFami = PlayerPrefs.GetInt("IdFamilier",0);


       

         string[] itemSaved= PlayerPrefs.GetString("iventoryItem","").Split(',');

       for (int i = 0 ; i < itemSaved.Length ; i++)
       {
            if(itemSaved[i] !="")
            {
                int id = int.Parse(itemSaved[i]);
                Item currentItem = itemDataBase.instance.allItem.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
       
       }
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount",Inventory.instance.coinsCount);
        
        if(currentSceneManager.instance.levelToUnlock >PlayerPrefs.GetInt("levelReached",1))
        {
            PlayerPrefs.SetInt("levelReached",currentSceneManager.instance.levelToUnlock );
        }
       
        string itemInInventory = string.Join(",",Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("iventoryItem", itemInInventory);

        PlayerPrefs.SetInt("IdFamilier", familierSet.instance.idFami);
       
    }
   
}
