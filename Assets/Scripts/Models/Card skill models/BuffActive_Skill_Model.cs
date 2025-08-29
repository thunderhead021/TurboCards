using System.Collections.Generic;

public class Player_BuffActive_LowSkill_Model : CardSkillModel
{
    public Player_BuffActive_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
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
        EffectSuit = DeckController.Instance.GetPlayerSuit();
        modifierValue = 1;
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


public class Player_BuffActive_HighSkill_Model : CardSkillModel
{
    public Player_BuffActive_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
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
        EffectSuit = DeckController.Instance.GetPlayerSuit();
        modifierValue = 2;
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


public class Other_BuffActive_LowSkill_Model : CardSkillModel
{
    public Other_BuffActive_LowSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
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
        EffectSuit = suit;
        modifierValue = 1;
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


public class Other_BuffActive_HighSkill_Model : CardSkillModel
{
    public Other_BuffActive_HighSkill_Model(int trainingReqiredTurns, SkillType skillType, SkillActivationType skillActivationType, int id) : base(trainingReqiredTurns, skillType, skillActivationType, id)
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
        EffectSuit = suit;
        modifierValue = 2;
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