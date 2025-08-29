using System;
using System.Collections.Generic;

public class TrainningController
{
    private List<TrainingModel> allModules = new();

    private List<CardSkillModel> allSkills = new();

    private TrainingModel[] currentModules = new TrainingModel[5];

    public TrainningController() 
    {
        AddTrainingModules();
        AddSkills();
    }

    private void AddTrainingModules() 
    {
        allModules.Add(new SmallBuffCard_TrainingModel());
        allModules.Add(new MedianBuffCard_TrainingModel());
        allModules.Add(new BigBuffCard_TrainingModel());
        allModules.Add(new MaxBuffCard_TrainingModel()); 
        allModules.Add(new SmallBuffEnemyCard_TrainingModel());
        allModules.Add(new MedianBuffEnemyCard_TrainingModel());
        allModules.Add(new BigBuffEnemyCard_TrainingModel());
        allModules.Add(new MaxBuffEnemyCard_TrainingModel());

        allModules.Add(new SmallDebuffCard_TrainingModel());
        allModules.Add(new MedianDebuffCard_TrainingModel());
        allModules.Add(new BigDebuffCard_TrainingModel());
        allModules.Add(new MaxDebuffCard_TrainingModel());
        allModules.Add(new SmallDebuffPlayerCard_TrainingModel());
        allModules.Add(new MedianDebuffPlayerCard_TrainingModel());
        allModules.Add(new BigDebuffPlayerCard_TrainingModel());
        allModules.Add(new MaxDebuffPlayerCard_TrainingModel());

        allModules.Add(new ConvertCardToPlayer_TrainingModel());
        allModules.Add(new ConvertCardToEnemy_TrainingModel());
        allModules.Add(new SwapCard_TrainingModel());
    }

    private void AddSkills() 
    {
        allSkills.Add(new Player_BuffTrap_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Trap, 0));
        allSkills.Add(new Player_BuffActive_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Active, 1));
        allSkills.Add(new Player_BuffEffect_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Effect, 2));

        allSkills.Add(new Other_BuffTrap_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Trap, 0));
        allSkills.Add(new Other_BuffActive_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Active, 1));
        allSkills.Add(new Other_BuffEffect_LowSkill_Model(4, SkillType.Buff, SkillActivationType.Effect, 2));

        allSkills.Add(new Player_BuffTrap_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Trap, 3));
        allSkills.Add(new Player_BuffActive_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Active, 4));
        allSkills.Add(new Player_BuffEffect_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Effect, 5));

        allSkills.Add(new Other_BuffTrap_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Trap, 3));
        allSkills.Add(new Other_BuffActive_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Active, 4));
        allSkills.Add(new Other_BuffEffect_HighSkill_Model(6, SkillType.Buff, SkillActivationType.Effect, 5));

        allSkills.Add(new Player_DebuffTrap_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Trap, 6));
        allSkills.Add(new Player_DebuffActive_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Active, 7));
        allSkills.Add(new Player_DebuffEffect_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Effect, 8));

        allSkills.Add(new Other_DebuffTrap_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Trap, 6));
        allSkills.Add(new Other_DebuffActive_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Active, 7));
        allSkills.Add(new Other_DebuffEffect_LowSkill_Model(4, SkillType.Debuff, SkillActivationType.Effect, 8));

        allSkills.Add(new Player_DebuffTrap_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Trap, 9));
        allSkills.Add(new Player_DebuffActive_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Active, 10));
        allSkills.Add(new Player_DebuffEffect_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Effect, 11));

        allSkills.Add(new Other_DebuffTrap_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Trap, 9));
        allSkills.Add(new Other_DebuffActive_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Active, 10));
        allSkills.Add(new Other_DebuffEffect_HighSkill_Model(6, SkillType.Debuff, SkillActivationType.Effect, 11));
    }

    public List<CardModel> AddAPlayerCardLowBuffSkill() 
    {
        Random rng = new();
        int index = rng.Next(0,2);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddACardLowBuffSkill()
    {
        Random rng = new();
        int index = rng.Next(3, 5);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddAPlayerCardHighBuffSkill()
    {
        Random rng = new();
        int index = rng.Next(6, 8);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddACardHighBuffSkill()
    {
        Random rng = new();
        int index = rng.Next(9, 11);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddAPlayerCardLowDebuffSkill()
    {
        Random rng = new();
        int index = rng.Next(12, 14);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddACardLowDebuffSkill()
    {
        Random rng = new();
        int index = rng.Next(15, 17);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddAPlayerCardHighDebuffSkill()
    {
        Random rng = new();
        int index = rng.Next(18, 20);
        return allSkills[index].Setup();
    }

    public List<CardModel> AddACardHighDebuffSkill()
    {
        Random rng = new();
        int index = rng.Next(21, 23);
        return allSkills[index].Setup();
    }

    public void SetATrainingModel(TrainingModel model, int slot) 
    {
        currentModules[slot] = model;
    }

    public void PerformTraining(int slot) 
    {
        currentModules[slot].Action();
    }

    public List<CardModel> PlayerBuff(int option) 
    {
        if (option >= 0 && option <= 3) 
        {
            switch (option) 
            {
                case 0:
                    return allModules[0].Action();
                case 1:
                    return allModules[1].Action(); 
                case 2:
                    return allModules[2].Action();
                case 3:
                    return allModules[3].Action();
            }
        }
        return null;
    }

    public List<CardModel> OtherBuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    return allModules[4].Action();
                case 1:
                    return allModules[5].Action();
                case 2:
                    return allModules[6].Action();
                case 3:
                    return allModules[7].Action();
            }
        }
        return null;
    }

    public List<CardModel> OtherDebuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    return allModules[8].Action();
                case 1:
                    return allModules[9].Action();
                case 2:
                    return allModules[10].Action();
                case 3:
                    return allModules[11].Action();
            }
        }
        return null;
    }

    public List<CardModel> PlayerDebuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    return allModules[12].Action();
                case 1:
                    return allModules[13].Action();
                case 2:
                    return allModules[14].Action();
                case 3:
                    return allModules[15].Action();
            }
        }
        return null;
    }

    public List<CardModel> ConvertToPlayer() 
    {
        return allModules[16].Action();
    }

    public List<CardModel> ConvertToOther() 
    {
        return allModules[17].Action();
    }

    public List<CardModel> Swap() 
    {
        return allModules[18].Action();
    }
}
