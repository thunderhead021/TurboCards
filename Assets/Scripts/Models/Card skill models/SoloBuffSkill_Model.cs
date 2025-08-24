using UnityEngine;

public class SoloBuffSkill_Model : CardSkillModel
{
    public SoloBuffSkill_Model(int trainingReqiredTurns, SkillType skillType) : base(trainingReqiredTurns, skillType)
    {
    }

    public override void Action(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        EffectSuit = suit;
        effectPostion = currentPosition;
        modifierValue = 2;
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }
}

public class SoloBuffOtherSkill_Model : CardSkillModel
{
    public SoloBuffOtherSkill_Model(int trainingReqiredTurns, SkillType skillType) : base(trainingReqiredTurns, skillType)
    {
    }

    public override void Action(int currentPosition, out int effectPostion, out int modifierValue, Suit? suit = null)
    {
        EffectSuit = suit;
        effectPostion = currentPosition;
        modifierValue = 2;
    }

    public override void Setup()
    {
        CardModel card = DeckController.Instance.GetARandomCardExclude();
        card.LearnASkill(this);
        DeckController.Instance.UpdateCard(card);
    }
}

