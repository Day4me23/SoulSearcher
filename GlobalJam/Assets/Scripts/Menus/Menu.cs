﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ButtonSettings()
    {

    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
