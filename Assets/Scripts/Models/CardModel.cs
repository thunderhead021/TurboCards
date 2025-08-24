using System;
using System.Collections.Generic;

public class CardModel
{
    private Suit CardSuit = (Suit)0;

    private int CardValue = 1;

    private readonly int id = -1;

    private List<CardSkillModel> skills = new();

    private CardSkillModel currentSkillInTraining = null;

    private int skillIsLearningProgress = -1;

    public List<CardSkillModel> GetCardSkills() { return skills; }

    public int GetId() => id;

    public Suit GetSuit() => CardSuit;

    public int GetCardValue() => CardValue;

    public int GetSkillIsLearningProgress() => skillIsLearningProgress;

    public int GetCurrentSkillTrainingReqiredTurns() => currentSkillInTraining != null ? currentSkillInTraining.TrainingReqiredTurns : 0;

    public bool? IsLearningABuffSkill => currentSkillInTraining != null ? currentSkillInTraining.CardSkillType == SkillType.Buff : null;

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
        this.currentSkillInTraining = skill;
        this.skillIsLearningProgress = 0;
    }

    public void LearningSkill() 
    {
        if (currentSkillInTraining != null) 
        {
            skillIsLearningProgress++;
            if (skillIsLearningProgress == currentSkillInTraining.TrainingReqiredTurns) 
            {
                AddSkill(currentSkillInTraining);
                currentSkillInTraining = null;
                skillIsLearningProgress = -1;
            }
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
