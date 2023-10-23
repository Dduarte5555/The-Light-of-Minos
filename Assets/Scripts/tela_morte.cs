using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tela_morte : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsVictory;
    public void Play()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        if(IsVictory){
            FindObjectOfType<AudioManager>().Stop("VictoryTheme");
        }
        else{
            FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
