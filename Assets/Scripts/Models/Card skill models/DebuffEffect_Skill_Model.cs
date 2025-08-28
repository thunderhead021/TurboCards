public class Player_DebuffEffect_LowSkill_Model : CardSkillModel
{
    public Player_DebuffEffect_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
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

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -1;
            amount = 2;
        }
        else
        {
            modifierValue = 0;
            amount = 0;
        }   
    }
}


public class Player_DebuffEffect_HighSkill_Model : CardSkillModel
{
    public Player_DebuffEffect_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
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

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -2;
            amount = 3;
        }
        else
        {
            modifierValue = 0;
            amount = 0;
        }
    }
}


public class Other_DebuffEffect_LowSkill_Model : CardSkillModel
{
    public Other_DebuffEffect_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
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

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -1;
            amount = 2;
        }
        else
        {
            modifierValue = 0;
            amount = 0;
        }
    }
}


public class Other_DebuffEffect_HighSkill_Model : CardSkillModel
{
    public Other_DebuffEffect_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
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

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -2;
            amount = 3;
        }
        else
        {
            modifierValue = 0;
            amount = 0;
        }
    }
}