using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invocDrake : MonoBehaviour
{
    public GameObject dragon;
    public Button plateauButton;
    
    public void invoc()
    {
        if(tourMiniJ.instance.nbActionDTour != 0)
        {
            if(tourMiniJ.instance.nbTour % 2 ==0)
            {
                dragon.SetActive(true);
                tourMiniJ.instance.EnleveAction();
                plateauButton.interactable = false;
            }
        }
    }
}
