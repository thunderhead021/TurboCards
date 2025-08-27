using UnityEngine;

public class DisplayResult : MonoBehaviour
{
    public bool IsForWin = false;
    public GameObject HavePrefab;
    public GameObject NotHavePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
