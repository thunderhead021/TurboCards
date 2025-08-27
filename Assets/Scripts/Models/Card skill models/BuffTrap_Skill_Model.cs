public class Player_BuffTrap_LowSkill_Model : CardSkillModel
{
    public Player_BuffTrap_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType) : base(trainingReqiredTurns, skillType, skillActivationType)
    {
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        EffectSuit = suit;
        effectPostion = currentPosition + 3;
        modifierValue = 1;
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardFromPlayerSuit();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}


public class Other_BuffTrap_LowSkill_Model : CardSkillModel
{
    public Other_BuffTrap_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType) : base(trainingReqiredTurns, skillType, skillActivationType)
    {
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        EffectSuit = suit;
        effectPostion = currentPosition + 3;
        modifierValue = 1;
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardExclude();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}


public class Player_BuffTrap_HighSkill_Model : CardSkillModel
{
    public Player_BuffTrap_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType) : base(trainingReqiredTurns, skillType, skillActivationType)
    {
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardFromPlayerSuit();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        effectPostion = currentPosition + 3;
        modifierValue = 2;
    }
}


public class Other_BuffTrap_HighSkill_Model : CardSkillModel
{
    public Other_BuffTrap_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType) : base(trainingReqiredTurns, skillType, skillActivationType)
    {
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardExclude();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        effectPostion = currentPosition + 3;
        modifierValue = 2;
    }
}
