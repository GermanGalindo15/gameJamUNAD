using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearCartas : MonoBehaviour
{
    public Transform position;
    public GameObject carta;
    public GameObject[] cartasToInstanciate;
    public int cantidad;
    
    // Start is called before the first frame update
    void Start()
    {
        cantidad = 16;
        iniciarCartas();
        //GameObject[] cartasToInstanciate = new GameObject[cantidad]
    }

    void iniciarCartas(){
        for(int i=0;i<cantidad;i++){
        GameObject[] cartasToInstanciate = new GameObject[cantidad];
        cartasToInstanciate[i]= Instantiate(carta,position);        
        if(i!=0)cartasToInstanciate[i].SetActive(false);
        }
    }

}
