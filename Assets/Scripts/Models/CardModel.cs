using System;
using System.Collections.Generic;

public class CardModel
{
    private Suit CardSuit = (Suit)0;

    private int CardValue = 1;

    private readonly int id = -1;

    private List<CardSkillModel> skills = new();

    private CardSkillModel currentSkillInTraining = null;

    private int turnUntilSkillIsLearn = -1;

    public int GetId() => id;

    public Suit GetSuit() => CardSuit;

    public int GetCardValue() => CardValue;

    public int GetTurnUntilSkillIsLearn() => turnUntilSkillIsLearn;

    public bool IsLearningASkill => currentSkillInTraining != null;

    public void ModifyValue(int modifier)
    {
        CardValue += modifier;

        if(CardValue > 13)
            CardValue = 13;
        else if (CardValue < 1)
            CardValue = 1;
    }

    public void ModifySuit(Suit suit)
    {
        CardSuit = suit;
    }

    public void LearnASkill(CardSkillModel skill) 
    {
        currentSkillInTraining = skill;
        turnUntilSkillIsLearn = skill.TrainingReqiredTurns;
    }

    public void LearningSkill() 
    {
        if (currentSkillInTraining != null) 
        {
            turnUntilSkillIsLearn--;
            if (turnUntilSkillIsLearn == 0) 
            {
                AddSkill(currentSkillInTraining);
                currentSkillInTraining = null;
                turnUntilSkillIsLearn = -1;
            }
        }
    }

    public void UseSkill() 
    {
        foreach (CardSkillModel skill in skills) 
        {
            skill.Action();
        }
    }

    public void AddSkill(CardSkillModel skill) 
    {
        skills.Add(skill);
    }

    public CardModel(Suit suit, int cardValue, int id) 
    {
        CardSuit = suit;
        CardValue = cardValue;
        Math.Clamp(CardValue, 1, 13);
        this.id = id;
    }
}


public enum Suit 
{
    Heart = 0,
    Diamond = 1,
    Club = 2,
    Spade = 3,
}
