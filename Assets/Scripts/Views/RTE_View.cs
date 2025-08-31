using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public abstract class RTE_View : MonoBehaviour
{
    [HideInInspector]
    public TrainingType trainingType;

    public List<GameObject> gameObjects;

    public GameObject Win;

    public GameObject Lose;

    [Range(0, 3)]
    public int difficulty = 0;

    public void Setup(int difficulty, TrainingType type)
    {
        this.difficulty = difficulty;
        this.trainingType = type;
    }

    public abstract void StartRTE();

    public void SendResult(bool success) 
    {
        StartCoroutine(SendResultCoroutine(success));
    }

    IEnumerator SendResultCoroutine(bool success) 
    {
        
        foreach (var gameObject in gameObjects) 
        {
            gameObject.SetActive(false);
        }
        if(success) 
            Win.SetActive(true);
        else
            Lose.SetActive(true);
        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        TrainingManager.Instance.QTAResult(success, trainingType, difficulty);
        Destroy(gameObject);
    }

}
