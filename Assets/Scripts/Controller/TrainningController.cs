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
        allSkills.Add(new SoloBuffSkill_Model(4, SkillType.Buff));
        allSkills.Add(new SoloBuffOtherSkill_Model(4, SkillType.Buff)); 
    }

    public void AddAPlayerCardBuffSkill() 
    {
        allSkills[0].Setup();
    }

    public void AddACardBuffSkill()
    {
        allSkills[1].Setup();
    }

    public void SetATrainingModel(TrainingModel model, int slot) 
    {
        currentModules[slot] = model;
    }

    public void PerformTraining(int slot) 
    {
        currentModules[slot].Action();
    }

    public void PlayerBuff(int option) 
    {
        if (option >= 0 && option <= 3) 
        {
            switch (option) 
            {
                case 0:
                    allModules[0].Action();
                    break;
                case 1:
                    allModules[1].Action(); 
                    break;
                case 2:
                    allModules[2].Action();
                    break;
                case 3:
                    allModules[3].Action();
                    break;
            }
        }
    }

    public void OtherBuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    allModules[4].Action();
                    break;
                case 1:
                    allModules[5].Action();
                    break;
                case 2:
                    allModules[6].Action();
                    break;
                case 3:
                    allModules[7].Action();
                    break;
            }
        }
    }

    public void OtherDebuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    allModules[8].Action();
                    break;
                case 1:
                    allModules[9].Action();
                    break;
                case 2:
                    allModules[10].Action();
                    break;
                case 3:
                    allModules[11].Action();
                    break;
            }
        }
    }

    public void PlayerDebuff(int option)
    {
        if (option >= 0 && option <= 3)
        {
            switch (option)
            {
                case 0:
                    allModules[12].Action();
                    break;
                case 1:
                    allModules[13].Action();
                    break;
                case 2:
                    allModules[14].Action();
                    break;
                case 3:
                    allModules[15].Action();
                    break;
            }
        }
    }

    public void ConvertToPlayer() 
    {
        allModules[16].Action();
    }

    public void ConvertToOther() 
    {
        allModules[17].Action();
    }

    public void Swap() 
    {
        allModules[18].Action();
    }
}
