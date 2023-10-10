using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniJ : MonoBehaviour
{
      public GameObject expli;
    public void expliOuvert()
    {
        expli.SetActive(true);
    }
    public void expliFerme()
    {
        expli.SetActive(false);
    }
}
