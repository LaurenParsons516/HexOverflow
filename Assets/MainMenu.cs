using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Sets scene to the 2D map
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits application
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
