using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject hud;
    public GameObject startMenu;


    void Awake()
    {
        Time.timeScale = 0;
    }

     public void StartGame()
    {
        Time.timeScale = 1;
        hud.SetActive(true);
        startMenu.SetActive(false);
    }
}
