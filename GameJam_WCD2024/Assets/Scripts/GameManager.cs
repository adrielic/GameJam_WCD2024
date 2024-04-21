using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int needsFood, needsWater, needsHerb, needsCampfire;
    public GameObject waterIcon, hungerIcon, herbIcon, campIcon, needsPnl, pausePnl;
    [SerializeField] private GameObject houseObj;
    [SerializeField] private float curTime, maxTimeInMinutes;

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

    IEnumerator Timer(float maxTime)
    {
        while (true)
        {
            if (curTime > maxTime * 60)
                Debug.Log("Acabou o tempo");

            yield return new WaitForSeconds(1);

            curTime++;
        }
    }
}
