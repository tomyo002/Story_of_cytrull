using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tourMiniJ : MonoBehaviour
{
    public int nbTour = 1;
    public GameObject tourH;
    public GameObject humain;
    public GameObject tourD;
    public GameObject dragon;
    public int nbActionD;
    public int nbActionDTour;
    public Text textActionD;
    public int nbActionH;
    public int nbActionHTour;
    public Text textActionH;

    public int powerD1 = 1;
    public int powerD2 = 1;
    public int powerD3 = 1;
    public Text textPowerD1;
    public Text textPowerD2;
    public Text textPowerD3;

    public static tourMiniJ instance;
  
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de tourMiniJdans la scene");
            return;
        }
        instance =this;
    }

    public void buttonTourH()
    {
        nbTour +=1;
        tourH.SetActive(false);
        humain.SetActive(false);
        tourD.SetActive(true);
        dragon.SetActive(true);
        nbActionDTour = nbActionD;
        UpdateTextUI();
    }

    public void buttonTourD()
    {
        nbTour +=1;
        tourH.SetActive(true);
        humain.SetActive(true);
        tourD.SetActive(false);
        dragon.SetActive(false);
        nbActionHTour =nbActionH;
        UpdateTextUI();
    }
     public void EnleveAction()
    {
        if(nbTour %2 == 0)
        {
            nbActionDTour -=1;
        }else{
            nbActionHTour -=1;
        }
        UpdateTextUI();
    }
    public void UpdateTextUI()
    {
        textActionD.text =nbActionDTour.ToString();
        textActionH.text =nbActionHTour.ToString();
        textPowerD1.text = powerD1.ToString();
        textPowerD2.text = powerD2.ToString();
        textPowerD3.text = powerD3.ToString();
    }
    public void powerD1Use()
    {
        if(powerD1 !=0)
        {
            powerD1 -= 1;
            UpdateTextUI();
        }
    }
    public void powerD2Use()
    {
        if(powerD2 !=0)
        {
            powerD2 -= 1;
            UpdateTextUI();

        }
    }
    public void powerD3Use()
    {
        if(powerD3 !=0)
        {
            powerD3 -= 1;
            UpdateTextUI();
        }
    }
}
