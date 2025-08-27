using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingManager : Manager<TrainingManager>
{
    [HideInInspector]
    public TrainningController trainningController = new();

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
        trainningController.AddAPlayerCardLowBuffSkill();
        trainningController.AddACardLowBuffSkill();
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
                    trainningController.OtherBuff(0);
                    if (difficulty != 3)
                        trainningController.OtherBuff(0);
                    if (difficulty == 2)
                        trainningController.OtherBuff(0);
                }
                else 
                {
                    switch (difficulty) 
                    {
                        case 1:
                            trainningController.OtherBuff(0);
                            trainningController.OtherBuff(0);
                            trainningController.OtherBuff(0);
                            trainningController.OtherBuff(0);
                            break;
                        default:
                            trainningController.OtherBuff(difficulty);
                            trainningController.OtherBuff(difficulty);
                            trainningController.OtherBuff(difficulty);
                            break;
                    }
                }
                break;
            case TrainingType.Debuff:
                if (isSucess)
                {
                    trainningController.OtherDebuff(difficulty);
                    trainningController.OtherDebuff(difficulty);
                }
                else 
                {
                    switch (difficulty) 
                    {
                        case 0:
                        case 1:
                            trainningController.PlayerDebuff(difficulty);
                            break;
                        case 2:
                        case 3:
                            trainningController.PlayerDebuff(difficulty);
                            trainningController.PlayerDebuff(difficulty);
                            break;
                    }
                }
                break;
            case TrainingType.BufSkill:
                if (isSucess)
                {
                    switch (difficulty) 
                    {
                        case 0:
                            trainningController.AddAPlayerCardLowBuffSkill();
                            trainningController.AddACardLowBuffSkill();
                            break;
                        case 1:
                            trainningController.AddAPlayerCardLowBuffSkill();
                            trainningController.AddAPlayerCardLowBuffSkill();
                            trainningController.AddACardLowBuffSkill();
                            break;
                        case 2:
                            trainningController.AddAPlayerCardHighBuffSkill();
                            trainningController.AddACardHighBuffSkill();
                            break;
                        case 3:
                            trainningController.AddAPlayerCardHighBuffSkill();
                            trainningController.AddAPlayerCardHighBuffSkill();
                            trainningController.AddACardHighBuffSkill();
                            break;
                    }
                }
                else 
                {
                    switch (difficulty)
                    {
                        case 0:
                            trainningController.AddACardLowBuffSkill();
                            trainningController.AddACardLowBuffSkill();
                            break;
                        case 1:
                            trainningController.AddACardLowBuffSkill();
                            trainningController.AddACardLowBuffSkill();
                            trainningController.AddACardLowBuffSkill();
                            break;
                        case 2:
                            trainningController.AddACardHighBuffSkill();
                            trainningController.AddACardHighBuffSkill();
                            break;
                        case 3:
                            trainningController.AddACardHighBuffSkill();
                            trainningController.AddACardHighBuffSkill();
                            trainningController.AddACardHighBuffSkill();
                            break;
                    }
                }
                break;
            case TrainingType.DebuffSkill:
                if (isSucess)
                {
                    switch (difficulty)
                    {
                        case 0:
                            trainningController.AddAPlayerCardLowDebuffSkill();
                            trainningController.AddACardLowDebuffSkill();
                            break;
                        case 1:
                            trainningController.AddAPlayerCardLowDebuffSkill();
                            trainningController.AddAPlayerCardLowDebuffSkill();
                            trainningController.AddACardLowDebuffSkill();
                            break;
                        case 2:
                            trainningController.AddAPlayerCardHighDebuffSkill();
                            trainningController.AddACardHighDebuffSkill();
                            break;
                        case 3:
                            trainningController.AddAPlayerCardHighDebuffSkill();
                            trainningController.AddAPlayerCardHighDebuffSkill();
                            trainningController.AddACardHighDebuffSkill();
                            break;
                    }
                }
                else
                {
                    switch (difficulty)
                    {
                        case 0:
                            trainningController.AddACardLowDebuffSkill();
                            trainningController.AddACardLowDebuffSkill();
                            break;
                        case 1:
                            trainningController.AddACardLowDebuffSkill();
                            trainningController.AddACardLowDebuffSkill();
                            trainningController.AddACardLowDebuffSkill();
                            break;
                        case 2:
                            trainningController.AddACardHighDebuffSkill();
                            trainningController.AddACardHighDebuffSkill();
                            break;
                        case 3:
                            trainningController.AddACardHighDebuffSkill();
                            trainningController.AddACardHighDebuffSkill();
                            trainningController.AddACardHighDebuffSkill();
                            break;
                    }
                }
                break;
            case TrainingType.ConvertSuit:
                if (isSucess) 
                {
                    switch (difficulty) 
                    {
                        case 0:
                            trainningController.Swap();
                            break;
                        case 1:
                            trainningController.Swap();
                            trainningController.Swap();
                            break;
                        case 2:
                            trainningController.ConvertToPlayer();
                            break;
                        case 3:
                            trainningController.ConvertToPlayer();
                            trainningController.ConvertToPlayer();
                            break;
                    }
                }
                else 
                {
                    switch (difficulty)
                    {
                        case 1:
                        case 2:
                            trainningController.ConvertToOther();
                            break;
                        case 3:
                            trainningController.ConvertToOther();
                            trainningController.ConvertToOther();
                            break;
                    }
                }
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