using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeCamaras : MonoBehaviour
{
    public GameObject camaraA, camaraB;
    public bool playerOneActive;
   // Update is called once per frame
    void Update()
    {
        if(playerOneActive)
        {
            camaraA.SetActive(false);
            camaraB.SetActive(true);
        }else{
            camaraA.SetActive(true);
            camaraB.SetActive(false);
        }
    }
}
