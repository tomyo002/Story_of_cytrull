
using UnityEngine;

public class itemDataBase : MonoBehaviour
{
    public Item[] allItem;
    public static  itemDataBase instance;
  
    private void Awake()
    {
        
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de  itemDataBase dans la scene");
            return;
        }
        instance =this;
    }
    
}
