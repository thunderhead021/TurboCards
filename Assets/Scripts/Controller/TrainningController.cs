using System.Collections.Generic;

public class TrainningController
{
    private List<TrainingModel> allModules = new();

    private TrainingModel[] currentModules = new TrainingModel[5];

    public TrainningController() 
    {

    }

    public void SetATrainingModel(TrainingModel model, int slot) 
    {
        currentModules[slot] = model;
    }

    public void PerformTraining(int slot) 
    {
        currentModules[slot].Action();
    }
}
