using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragonAnim : MonoBehaviour
{
    public Animator dragonAnimator;
    public bool isOeuf = true;
    public bool isBaby = false;
    public bool isAdult = false;
    public bool isCouronne = false;
    public bool isTel = false;
    public bool isYing =false;
    public GameObject dragon;
    public GameObject dragonV;
    public GameObject dragonCCorp1;
    public GameObject dragonCCorp2;
    public GameObject dragonCQueue;

    public Button button1Pla;
    public Button button2Pla;
    public Button button3Pla;
    public Button platBebeC;

    public GameObject power1;
    public GameObject power2;
    public GameObject power3; 
    public GameObject interfaceM;

    public int nbAppa = 0;

   
    // Update is called once per frame
    void Update()
    {
        if(dragon.activeInHierarchy == true && nbAppa == 0)
        {
            nbAppa = tourMiniJ.instance.nbTour;
            isOeuf = true;
            isBaby = false;
        }

        if(tourMiniJ.instance.nbTour - nbAppa  == 2)
        {
            isOeuf = false;
            isBaby = true;
        }
        if(tourMiniJ.instance.nbTour - nbAppa == 6)
        {
            isBaby = false;
            isAdult = true;
        }
        dragonAnimator.SetBool("isOeuf",isOeuf);
        dragonAnimator.SetBool("isBaby",isBaby);
        dragonAnimator.SetBool("isAdult",isAdult);
        dragonAnimator.SetBool("isCouronne",isCouronne);
        dragonAnimator.SetBool("isTel",isTel);
        dragonAnimator.SetBool("isYing",isYing);

        
    }
    public void buttonDragon()
    {
        if(isTel == false && isCouronne == false && isYing == false)
        {
            if(power1.activeInHierarchy == true)
            {
                power1.SetActive(false);
                power2.SetActive(false);
                power3.SetActive(false);

            }
            else{
                power1.SetActive(true);
                power2.SetActive(true);
                power3.SetActive(true);
            }
        }else{
            if(isTel)
            {
                interfaceM.SetActive(true);
            }
            
        }
        
    }
    public void PowerUseCourrone()
    {
        if(isBaby == true && tourMiniJ.instance.powerD1 !=0)
        {
            isCouronne = true;
            nbAppa = 999;
            power1.SetActive(false);
            power2.SetActive(false);
            power3.SetActive(false);
            tourMiniJ.instance.powerD1Use();
            tourMiniJ.instance.nbActionD +=1;
            tourMiniJ.instance.nbActionDTour = tourMiniJ.instance.nbActionD;
            tourMiniJ.instance.UpdateTextUI();
            dragonV.SetActive(true);
            platBebeC.interactable = false;
        }
    }
    public void powerUseTel()
    {
         if(isBaby == true && tourMiniJ.instance.powerD2 !=0)
        {
            isTel = true;
            nbAppa = 999;
            tourMiniJ.instance.powerD2Use();
            power1.SetActive(false);
            power2.SetActive(false);
            power3.SetActive(false);
        }
    }
    public void buttonCroixInterfaceMirroir()
    {
        interfaceM.SetActive(false);
    }

    public void powerUseYing()
    {
         if(isBaby == true && tourMiniJ.instance.powerD3 !=0)
        {
            isYing = true;
            nbAppa = 999;
            tourMiniJ.instance.powerD3Use();
            power1.SetActive(false);
            power2.SetActive(false);
            power3.SetActive(false);
            dragonCQueue.SetActive(true);
            dragonCCorp1.SetActive(true);
            dragonCCorp2.SetActive(true);

            button1Pla.interactable = false;
            button2Pla.interactable = false;
            button3Pla.interactable = false;
        }
    }
}
