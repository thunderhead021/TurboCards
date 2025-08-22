using System.Collections.Generic;

public class TrainningController
{
    private List<TrainingModel> allModules = new();

    private TrainingModel[] currentModules = new TrainingModel[5];

    public TrainningController() 
    {
        allModules.Add(new SmallBuffCard_TrainingModel());
        allModules.Add(new MedianBuffCard_TrainingModel());
        allModules.Add(new BigBuffCard_TrainingModel());
        allModules.Add(new SmallBuffEnemyCard_TrainingModel());
        allModules.Add(new MedianBuffEnemyCard_TrainingModel());
        allModules.Add(new BigBuffCard_TrainingModel());

        allModules.Add(new SmallDebuffCard_TrainingModel());
        allModules.Add(new MedianDebuffCard_TrainingModel());
        allModules.Add(new BigDebuffCard_TrainingModel());
        allModules.Add(new SmallDebuffPlayerCard_TrainingModel());
        allModules.Add(new MedianDebuffPlayerCard_TrainingModel());
        allModules.Add(new BigDebuffPlayerCard_TrainingModel());
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
        if (option >= 0 && option <= 2) 
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
            }
        }
    }

    public void OtherBuff(int option)
    {
        if (option >= 0 && option <= 2)
        {
            switch (option)
            {
                case 0:
                    allModules[3].Action();
                    break;
                case 1:
                    allModules[4].Action();
                    break;
                case 2:
                    allModules[5].Action();
                    break;
            }
        }
    }

    public void OtherDebuff(int option)
    {
        if (option >= 0 && option <= 2)
        {
            switch (option)
            {
                case 0:
                    allModules[6].Action();
                    break;
                case 1:
                    allModules[7].Action();
                    break;
                case 2:
                    allModules[8].Action();
                    break;
            }
        }
    }

    public void PlayerDebuff(int option)
    {
        if (option >= 0 && option <= 2)
        {
            switch (option)
            {
                case 0:
                    allModules[9].Action();
                    break;
                case 1:
                    allModules[10].Action();
                    break;
                case 2:
                    allModules[11].Action();
                    break;
            }
        }
    }
}
