using System.Collections;
using UnityEngine;

public class DisplayResult : MonoBehaviour
{
    public bool IsForWin = false;
    public GameObject HavePrefab;
    public GameObject NotHavePrefab;
    public GameObject ResultContinue;
    public GameObject ResultFinish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartAnimationCoroutine());
    }

    private IEnumerator StartAnimationCoroutine()
    {
        int max = 5;
        if (IsForWin)
        {
            max = 10;
        }
        for (int i = 0; i < max; i++)
        {
            if (IsForWin)
            {
                Instantiate(RaceManager.Instance.WinCount > i ? HavePrefab : NotHavePrefab, transform);
            }
            else
            {
                Instantiate(RaceManager.Instance.Heath > i ? HavePrefab : NotHavePrefab, transform);
            }
            float elapsed = 0f;
            while (elapsed < 0.5f)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
        if (IsForWin) 
        {
            if(RaceManager.Instance.WinCount == max)
                ResultFinish.SetActive(true);
            else
                ResultContinue.SetActive(true);
        }
        else 
        {
            if (RaceManager.Instance.Heath <= 0) 
                ResultFinish.SetActive(true);
            else
                ResultContinue.SetActive(true);
        }
    }
}
