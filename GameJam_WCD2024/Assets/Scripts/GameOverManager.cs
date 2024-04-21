using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Retry()
    {
        GameManager.instance.RestartLevel();
    }

    public void Menu()
    {
        GameManager.instance.ReturnToMenu();
    }
}
