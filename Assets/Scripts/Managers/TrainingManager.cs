using System.Collections.Generic;
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

    public List<RTE_View> RTAEvents;

    public List<Activity_View> Activities;

    public int minDifficulty = 0;

    public void StartAnActivity(int difficult, TrainingType trainingType) 
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Playmat");
        RTE_View rTE_View = Instantiate(RTAEvents[Random.Range(0, RTAEvents.Count)], canvas.transform);
        rTE_View.Setup(difficult, trainingType);
    }

    public void DecreaseValue() 
    {
        
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
        ShuffleActivities();
    }

    public void ShuffleActivities() 
    {
        for (int i = Activities.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (Activities[i], Activities[j]) = (Activities[j], Activities[i]);
        }
        for (int i = 0; i < Activities.Count; i++)
        {
            Activities[i].SetDifficulty(minDifficulty + i);
        }
    }

    private void UpDateTrainingAmount() 
    {
        TrainingAmount--;
        ShuffleActivities();
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

    public void QTAResult(bool isSucess, TrainingType trainingType, int difficulty) 
    {
        switch (trainingType) 
        {
            case TrainingType.Buff:
                if (isSucess)
                {
                    trainningController.PlayerBuff(difficulty);
                }
                trainningController.OtherBuff(0);
                trainningController.OtherBuff(0);
                break;
            case TrainingType.Debuff:
                if (isSucess)
                {
                    trainningController.OtherDebuff(difficulty);
                    trainningController.OtherDebuff(difficulty);
                }
                else 
                {
                    trainningController.PlayerDebuff(difficulty);
                    trainningController.PlayerDebuff(difficulty);
                }
                break;
            case TrainingType.BufSkill: 
                break;
            case TrainingType.DebuffSkill:
                break;
            case TrainingType.ConvertSuit:
                break;
        }
        UpDateTrainingAmount();
        GameObject deck = GameObject.FindGameObjectWithTag("Deck");
        if (deck != null) 
        {
            deck.GetComponent<DeckView>().ShowDeck();
        }
    }
}

public enum TrainingType 
{
    Buff,
    Debuff,
    BufSkill,
    DebuffSkill,
    ConvertSuit
}