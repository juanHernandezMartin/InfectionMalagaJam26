using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject hud;
    public GameObject startMenu;


    void Start()
    {
        Time.timeScale = 0;
    }

     public void StartGame()
    {
        Time.timeScale = 1;
        hud.SetActive(true);
        startMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
