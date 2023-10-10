using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class invocBonh : MonoBehaviour
{
  public GameObject bonHO;
  public GameObject zoneApp;
  public GameObject myCanvas;



  public void clone()
  {
    if(tourMiniJ.instance.nbActionHTour != 0)
    {
      GameObject bonHclone = Instantiate(bonHO, new Vector3(zoneApp.transform.position.x, zoneApp.transform.position.y, zoneApp.transform.position.z), zoneApp.transform.rotation,myCanvas.transform.parent);
      tourMiniJ.instance.EnleveAction();
    }
    
  }
      
 
  
         
        
}
