using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void LoadTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void LoadPractice()
    {
        SceneManager.LoadScene("practice");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
