using UnityEngine;

public abstract class CardSkillModel
{
    public int TrainingReqiredTurns = -1;

    protected CardSkillModel(int trainingReqiredTurns) 
    {
        TrainingReqiredTurns = trainingReqiredTurns;
    }

    public abstract void Action();
}
