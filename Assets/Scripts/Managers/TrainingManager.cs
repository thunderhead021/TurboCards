using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingManager : Manager<TrainingManager>
{
    [HideInInspector]
    public TrainningController trainningController = new();

    [HideInInspector]
    public DeckController DeckController = new();

    [HideInInspector]
    public int TrainingAmount = 5;

    public DeckView DeckView;

    public TrainingUIView uIView;

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

    public void LearnABuffSkillValue()
    {
        trainningController.AddAPlayerCardBuffSkill();
        trainningController.AddACardBuffSkill();
        UpDateTrainingAmount();
    }

    public void ResetTrainingAmount() 
    {
        TrainingAmount = 5;
        uIView.UpdateRemainTurn(TrainingAmount);
    }

    private void UpDateTrainingAmount() 
    {
        TrainingAmount--;
        uIView.UpdateRemainTurn(TrainingAmount);
        foreach (var card in DeckController.Instance.ReadOnlyDeck) 
        {
            card.LearningSkill();
        }

        if (TrainingAmount <= 0)
        {
            SceneManager.LoadScene("Run Scene");
        }
    }
}
