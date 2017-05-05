using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    /*
     * Button listeners to load scene associated with the button
     */ 
    public void LoadTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void LoadPractice()
    {
        SceneManager.LoadScene("practice");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
