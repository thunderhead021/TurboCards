using UnityEngine;

public abstract class CardSkillModel
{
    public int TrainingReqiredTurns = -1;

    public Suit? EffectSuit = null;

    public SkillType? CardSkillType = null;
    
    public SkillActivationType skillActivationType = SkillActivationType.None;

    protected CardSkillModel(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType) 
    {
        TrainingReqiredTurns = trainingReqiredTurns;
        CardSkillType = skillType;
        this.skillActivationType = skillActivationType;
    }

    public abstract void Setup();

    public abstract void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null);

    public abstract void ActiveAction(out int modifierValue, Suit? suit = null);

    public abstract void EffectAction(out int modifierValue, out int amount, Suit? suit = null);
}

public enum SkillType 
{
    Buff,
    Debuff
}

public enum SkillActivationType 
{
    None,
    Trap,
    Active,
    Effect
}