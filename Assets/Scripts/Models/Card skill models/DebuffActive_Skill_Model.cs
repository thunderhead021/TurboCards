using System.Collections.Generic;

public class Player_DebuffActive_LowSkill_Model : CardSkillModel
{
    public Player_DebuffActive_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
    }

    public override List<CardModel> Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardFromPlayerSuit();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
        return new List<CardModel>() { card };
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -1;
        }
        else
        {
            modifierValue = 0;
        }
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}


public class Player_DebuffActive_HighSkill_Model : CardSkillModel
{
    public Player_DebuffActive_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
    }

    public override List<CardModel> Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardFromPlayerSuit();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
        return new List<CardModel>() { card };
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -2;
        }
        else
        {
            modifierValue = 0;
        }
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}


public class Other_DebuffActive_LowSkill_Model : CardSkillModel
{
    public Other_DebuffActive_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
    }

    public override List<CardModel> Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardExclude();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
        return new List<CardModel>() { card };
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -1;
        }
        else
        {
            modifierValue = 0;
        }
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}


public class Other_DebuffActive_HighSkill_Model : CardSkillModel
{
    public Other_DebuffActive_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
    {
    }

    public override List<CardModel> Setup()
    {
        CardModel card = DeckController.Instance.GetARandomNotLearningCardExclude();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
        return new List<CardModel>() { card };
    }

    public override void ActiveAction(out int modifierValue, Suit? suit = null)
    {
        if (suit is Suit cardSuit)
        {
            EffectSuit = DeckController.Instance.GetARandomCardExclude(cardSuit).GetSuit();
            modifierValue = -2;
        }
        else
        {
            modifierValue = 0;
        }
    }

    public override void TrapAction(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }

    public override void EffectAction(out int modifierValue, out int amount, Suit? suit = null)
    {
        throw new System.NotImplementedException();
    }
}