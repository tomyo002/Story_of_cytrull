using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourPossibleH : MonoBehaviour
{
    public GameObject[] zoneAppH;
    
    // Update is called once per frame
    void Update()
    {
        
    if(tourMiniJ.instance.nbTour % 2 ==0)
    {
        foreach (GameObject element in zoneAppH)
        {
            element.SetActive(false);
        }
      
    }else{
      foreach (GameObject element in zoneAppH)
        {
            element.SetActive(true);
        }
    }
    }
}
