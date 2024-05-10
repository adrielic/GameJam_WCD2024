using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int needsFood, needsWater, needsHerb, needsCampfire;
    public GameObject waterIcon, hungerIcon, herbIcon, campIcon, needsPnl, pausePnl, gameOverPnl;
    [SerializeField] private float curTime, maxTimeInMinutes;
    [SerializeField] private GameObject houseObj;
    [SerializeField] private GameObject deathTimeOut, deathHerb, deathDrowned, deathBear, deathRavine;
    public bool levelDone;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        StartCoroutine(Timer(maxTimeInMinutes));
    }

    void Update()
    {
        NeedsSystem();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePnl.SetActive(true);
            needsPnl.SetActive(false);
        }
    }

    void NeedsSystem()
    {
        if (needsFood <= 0 && needsWater <= 0 && needsHerb <= 0 && needsCampfire <= 0)
            houseObj.GetComponent<Collider2D>().enabled = true;

        if (needsWater > 0)
            waterIcon.GetComponent<Animator>().SetBool("IsNeeded", true);
        else
            waterIcon.GetComponent<Animator>().SetBool("IsNeeded", false);

        if (needsFood > 0)
            hungerIcon.GetComponent<Animator>().SetBool("IsNeeded", true);
        else
            hungerIcon.GetComponent<Animator>().SetBool("IsNeeded", false);

        if (needsHerb > 0)
            herbIcon.GetComponent<Animator>().SetBool("IsNeeded", true);
        else
            herbIcon.GetComponent<Animator>().SetBool("IsNeeded", false);

        if (needsCampfire > 0)
            campIcon.GetComponent<Animator>().SetBool("IsNeeded", true);
        else
            campIcon.GetComponent<Animator>().SetBool("IsNeeded", false);
    }

    public void NextLevel()
    {
        LevelLoader.instance.LoadScene("Next");
    }

    public void RestartLevel()
    {
        LevelLoader.instance.LoadScene("Reload");
    }

    public void ReturnToMenu()
    {
        LevelLoader.instance.LoadScene("First");
    }

    public void Death(string death)
    {
        switch (death)
        {
            case "TimeOut":
                gameOverPnl.SetActive(true);
                deathTimeOut.SetActive(true);
                break;
            case "Herb":
                gameOverPnl.SetActive(true);
                deathHerb.SetActive(true);
                break;
            case "Drowned":
                gameOverPnl.SetActive(true);
                deathDrowned.SetActive(true);
                break;
            case "Bear":
                gameOverPnl.SetActive(true);
                deathBear.SetActive(true);
                break;
            case "Ravine":
                gameOverPnl.SetActive(true);
                deathRavine.SetActive(true);
                break;
        }

        needsPnl.SetActive(false);
    }

    IEnumerator Timer(float maxTime)
    {
        while (true)
        {
            if (curTime > maxTime * 60)
            {
                if (!levelDone)
                    Death("TimeOut");
            }

            yield return new WaitForSeconds(1);

            curTime++;
        }
    }
}
