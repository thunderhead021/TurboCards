using UnityEngine;

public class Activity_View : MonoBehaviour
{
    [HideInInspector]
    public int difficulty = 0;
    public TrainingType trainingType;

    public void SetDifficulty(int difficulty) 
    {
        this.difficulty = difficulty;
    }

    public void StartActivity() 
    {
        TrainingManager.Instance.StartAnActivity(difficulty, trainingType);
    }

}
