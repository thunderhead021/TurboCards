using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingManager : Manager<TrainingManager>
{
    [HideInInspector]
    public DeckController deckController = new();

    [HideInInspector]
    public TrainningController trainningController = new();

    [HideInInspector]
    public int TrainingAmount = 5;

    public DeckView DeckView;

    public void IncreaseValue() 
    {
        trainningController.PlayerBuff(0);
        trainningController.OtherBuff(0);
        trainningController.OtherBuff(0);
        UpDateTrainingAmount();
    }

    public void DecreaseValue() 
    {
        trainningController.OtherDebuff(0);
        trainningController.OtherDebuff(0);
        UpDateTrainingAmount();
    }

    public void ResetTrainingAmount() 
    {
        TrainingAmount = 5;
    }

    private void UpDateTrainingAmount() 
    {
        TrainingAmount--;
        if (TrainingAmount <= 0)
        {
            SceneManager.LoadScene("Run Scene");
        }
    }
}
