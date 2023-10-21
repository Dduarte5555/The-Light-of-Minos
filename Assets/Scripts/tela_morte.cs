using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tela_morte : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
