using UnityEngine;

public abstract class CardSkillModel
{
    public int TrainingReqiredTurns = -1;

    public Suit? EffectSuit = null;

    public SkillType? CardSkillType = null;
    
    protected CardSkillModel(int trainingReqiredTurns, SkillType skillType) 
    {
        TrainingReqiredTurns = trainingReqiredTurns;
        CardSkillType = skillType;
    }

    public abstract void Setup();

    public abstract void Action(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null);
}

public enum SkillType 
{
    Buff,
    Debuff
}