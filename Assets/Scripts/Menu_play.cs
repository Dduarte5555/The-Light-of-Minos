using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_play : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
