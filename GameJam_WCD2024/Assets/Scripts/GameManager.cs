using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int needsFood, needsWater, needsHerb, needsCampfire;
    public GameObject waterIcon, hungerIcon, herbIcon, campIcon, needsPnl, pausePnl;
    [SerializeField] private GameObject houseObj;

    [SerializeField] private float curTime, maxTimeInMinutes;

    [SerializeField] private GameObject deathTimeOut, deathHerb, deathDrowned, deathBear, deathRavine;

    void Awake()
    {
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
        Debug.Log(needsFood + ", " + needsWater + ", " + needsHerb + ", " + needsCampfire);

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
        int curScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(curScene + 1);
    }

    public void RestartLevel()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(curScene);
    }

    public void Death(string death)
    {
        switch (death)
        {
            case "TimeOut":
                deathTimeOut.SetActive(true);
                break;
            case "Herb":
                deathHerb.SetActive(true);
                break;
            case "Drowned":
                deathDrowned.SetActive(true);
                break;
            case "Bear":
                deathBear.SetActive(true);
                break;
            case "Ravine":
                deathRavine.SetActive(true);
                break;
        }
    }



    IEnumerator Timer(float maxTime)
    {
        while (true)
        {
            if (curTime > maxTime * 60)
                Death("TimeOut");

            yield return new WaitForSeconds(1);

            curTime++;
        }
    }
}
