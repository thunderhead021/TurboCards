using System.Collections.Generic;

public abstract class CardSkillModel
{
    public int TrainingReqiredTurns = -1;

    public Suit? EffectSuit = null;

    public SkillType? CardSkillType = null;
    
    public SkillActivationType skillActivationType = SkillActivationType.None;

    public int ID = -1;

    protected CardSkillModel(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) 
    {
        TrainingReqiredTurns = trainingReqiredTurns;
        CardSkillType = skillType;
        this.skillActivationType = skillActivationType;
        ID = id;    
    }

    public abstract List<CardModel> Setup();

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