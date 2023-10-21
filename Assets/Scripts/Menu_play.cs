using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_play : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    public void OnPlayButton ()
    {
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("Opening");
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
