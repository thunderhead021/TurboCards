using UnityEngine;

public abstract class RTE_View : MonoBehaviour
{
    [HideInInspector]
    public TrainingType trainingType;

    [Range(0, 3)]
    public int difficulty = 0;

    public void Setup(int difficulty, TrainingType type)
    {
        this.difficulty = difficulty;
        this.trainingType = type;
    }
}
