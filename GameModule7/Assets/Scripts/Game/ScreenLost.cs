using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLost : MonoBehaviour
{
    [SerializeField] private GameObject lost;

    public void LostScreen()
    {
        lost.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameSceen");
    }
}
