using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject screenPause;
    [SerializeField] private GameObject Menu;

    private bool paused;

    public void PauseGame()
    {
        if (paused)
        {
            screenPause.SetActive(false);
            Time.timeScale = 1;
        }
        else
        { 
            screenPause.SetActive(true);
            Time.timeScale = 0;
        }

        paused = !paused;
    }

    public void ContinueButtin()
    { 
        screenPause.SetActive(false);
        Time.timeScale = 1;
        paused = !paused;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameSceen");
        paused = !paused;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        
    }
}
