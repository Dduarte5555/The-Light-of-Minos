using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void ChangeScene(){
        //Destroy(objeto);
        SceneManager.LoadScene("Scenes/tela_morte");
        FindObjectOfType<AudioManager>().Play("GameOverTheme");
    }

}