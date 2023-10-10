using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoBonhomme : MonoBehaviour
{

    public GameObject[] buttonB;
    public GameObject[] caseDeplacement;
    private GameObject rangement ;
    public GameObject luiMeme;
    public GameObject ZoneInvisible;
    public GameObject myCanvas;
    private bool pos = false;


    public void AppDisButton()
    {
        if(buttonB[0].activeInHierarchy == false)
        {
            foreach(GameObject element in buttonB)
            {
                element.SetActive(true);
            }
            
        }else{

            foreach(GameObject element in buttonB)
            {
                element.SetActive(false);
            }
            
        }
    }

    public void deplacement()
    {
        if(pos == false)
        {
            foreach(GameObject element in caseDeplacement)
            {
               
                element.SetActive(true);
  
                pos = true;
                
            }
            GameObject zoneTrou = Instantiate(ZoneInvisible, new Vector3(ZoneInvisible.transform.position.x, ZoneInvisible.transform.position.y, ZoneInvisible.transform.position.z), ZoneInvisible.transform.rotation,myCanvas.transform.parent);
            rangement = zoneTrou;
            rangement.SetActive(true);
        }else{

            foreach(GameObject element in caseDeplacement)
            {
                element.SetActive(false);
                pos = false;
            }
            Destroy(rangement);
        
        }
    }


    public void caseDeplace(int nombreCase)
    {
        if(tourMiniJ.instance.nbActionHTour != 0)
        {
            if(tourMiniJ.instance.nbTour % 2 ==1)
            {
                
                
                    deplacement();
                    AppDisButton();
                    GameObject bonHclone = Instantiate(luiMeme, new Vector3(caseDeplacement[nombreCase].transform.position.x, caseDeplacement[nombreCase].transform.position.y, caseDeplacement[nombreCase].transform.position.z), caseDeplacement[nombreCase].transform.rotation,myCanvas.transform.parent);
                    
                    tourMiniJ.instance.EnleveAction();

                    Destroy( luiMeme);
                }
            
        }
    }

}

