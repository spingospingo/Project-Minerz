﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    //Method for Starting the game
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Loads Scene with index of "1"
    }

    //Method for quitting the game
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //Shows in that the player quit the debug log 
        Application.Quit(); //Quits the Application
    }
}
