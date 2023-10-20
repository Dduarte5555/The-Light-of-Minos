using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject objeto;
    void Start()
    {
        //objeto = this.GetComponent<GameObject>();
        
    }

    void Death(){
        Destroy(objeto);
    }

}