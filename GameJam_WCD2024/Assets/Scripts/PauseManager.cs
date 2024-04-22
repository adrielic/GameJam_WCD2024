using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }
    
    public void Resume()
    {
        gameObject.SetActive(false);
        GameManager.instance.needsPnl.SetActive(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.ReturnToMenu();
    }
}
