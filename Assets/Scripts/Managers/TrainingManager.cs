using System.Collections;
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

    public Transform CardModifedTray;

    public CardView cardPrefab;

    [HideInInspector]
    public List<Activity_View> Active_Activities = new();

    public int minDifficulty = 0;

    public void StartAnActivity(int difficult, TrainingType trainingType)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Playmat");
        RTE_View rTE_View = Instantiate(RTAEvents[Random.Range(0, RTAEvents.Count)], canvas.transform);
        rTE_View.Setup(difficult, trainingType);
    }

    public void ResetTrainingAmount()
    {
        TrainingAmount = 5;
        uIView.UpdateRemainTurn(TrainingAmount);
        Active_Activities.Clear();
        switch (DeckController.Instance.GetPlayerSuit())
        {
            //normal 
            case (Suit)0:
                Active_Activities.Add(Activities[0]);
                Active_Activities.Add(Activities[1]);
                Active_Activities.Add(Activities[4]);
                break;
            //hardworking 
            case (Suit)1:
                Active_Activities.Add(Activities[0]);
                Active_Activities.Add(Activities[2]);
                Active_Activities.Add(Activities[3]);
                break;
            //caring
            case (Suit)2:
                Active_Activities.Add(Activities[0]);
                Active_Activities.Add(Activities[2]);
                Active_Activities.Add(Activities[4]);
                break;
            //prankster 
            case (Suit)3:
                Active_Activities.Add(Activities[1]);
                Active_Activities.Add(Activities[3]);
                Active_Activities.Add(Activities[4]);
                break;
        }
        ShuffleActivities();
    }

    public void ShuffleActivities()
    {
        for (int i = Active_Activities.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (Active_Activities[i], Active_Activities[j]) = (Active_Activities[j], Active_Activities[i]);
        }
        for (int i = 0; i < Active_Activities.Count; i++)
        {
            Active_Activities[i].SetDifficulty(minDifficulty + i);
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
            StartCoroutine(LoadRunSceneCoroutine());
        }
    }

    IEnumerator LoadRunSceneCoroutine() 
    {
        SceneManager.LoadScene("Run Scene");
        yield return new WaitForSecondsRealtime(1);
        RaceManager.Instance.CreateRaceTrack(70 + (GameManager.Instance.round + 1) * 10);
    }

    public void QTAResult(bool isSucess, TrainingType trainingType, int difficulty)
    {
        List<CardModel> result = new();
        switch (trainingType)
        {
            case TrainingType.Buff:
                if (isSucess)
                {
                    result.AddRange(trainningController.PlayerBuff(difficulty));
                    result.AddRange(trainningController.OtherBuff(0));
                    if (difficulty != 3)
                        result.AddRange(trainningController.OtherBuff(0));
                    if (difficulty == 2)
                        result.AddRange(trainningController.OtherBuff(0));
                }
                else
                {
                    switch (difficulty)
                    {
                        case 1:
                            result.AddRange(trainningController.OtherBuff(0));
                            result.AddRange(trainningController.OtherBuff(0));
                            result.AddRange(trainningController.OtherBuff(0));
                            result.AddRange(trainningController.OtherBuff(0));
                            break;
                        default:
                            result.AddRange(trainningController.OtherBuff(difficulty));
                            result.AddRange(trainningController.OtherBuff(difficulty));
                            result.AddRange(trainningController.OtherBuff(difficulty));
                            break;
                    }
                }
                break;
            case TrainingType.Debuff:
                if (isSucess)
                {
                    result.AddRange(trainningController.OtherDebuff(difficulty));
                    result.AddRange(trainningController.OtherDebuff(difficulty));
                }
                else
                {
                    switch (difficulty)
                    {
                        case 0:
                        case 1:
                            result.AddRange(trainningController.PlayerDebuff(difficulty));
                            break;
                        case 2:
                        case 3:
                            result.AddRange(trainningController.PlayerDebuff(difficulty));
                            result.AddRange(trainningController.PlayerDebuff(difficulty));
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
                            result.AddRange(trainningController.AddAPlayerCardLowBuffSkill());
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            break;
                        case 1:
                            result.AddRange(trainningController.AddAPlayerCardLowBuffSkill());
                            result.AddRange(trainningController.AddAPlayerCardLowBuffSkill());
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            break;
                        case 2:
                            result.AddRange(trainningController.AddAPlayerCardHighBuffSkill());
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            break;
                        case 3:
                            result.AddRange(trainningController.AddAPlayerCardHighBuffSkill());
                            result.AddRange(trainningController.AddAPlayerCardHighBuffSkill());
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            break;
                    }
                }
                else
                {
                    switch (difficulty)
                    {
                        case 0:
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            break;
                        case 1:
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            result.AddRange(trainningController.AddACardLowBuffSkill());
                            break;
                        case 2:
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            break;
                        case 3:
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            result.AddRange(trainningController.AddACardHighBuffSkill());
                            result.AddRange(trainningController.AddACardHighBuffSkill());
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
                            result.AddRange(trainningController.AddAPlayerCardLowDebuffSkill());
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            break;
                        case 1:
                            result.AddRange(trainningController.AddAPlayerCardLowDebuffSkill());
                            result.AddRange(trainningController.AddAPlayerCardLowDebuffSkill());
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            break;
                        case 2:
                            result.AddRange(trainningController.AddAPlayerCardHighDebuffSkill());
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            break;
                        case 3:
                            result.AddRange(trainningController.AddAPlayerCardHighDebuffSkill());
                            result.AddRange(trainningController.AddAPlayerCardHighDebuffSkill());
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            break;
                    }
                }
                else
                {
                    switch (difficulty)
                    {
                        case 0:
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            break;
                        case 1:
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            result.AddRange(trainningController.AddACardLowDebuffSkill());
                            break;
                        case 2:
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            break;
                        case 3:
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
                            result.AddRange(trainningController.AddACardHighDebuffSkill());
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
                            result.AddRange(trainningController.Swap());
                            break;
                        case 1:
                            result.AddRange(trainningController.Swap());
                            result.AddRange(trainningController.Swap());
                            break;
                        case 2:
                            result.AddRange(trainningController.ConvertToPlayer());
                            break;
                        case 3:
                            result.AddRange(trainningController.ConvertToPlayer());
                            result.AddRange(trainningController.ConvertToPlayer());
                            break;
                    }
                }
                else
                {
                    switch (difficulty)
                    {
                        case 1:
                        case 2:
                            result.AddRange(trainningController.ConvertToOther());
                            break;
                        case 3:
                            result.AddRange(trainningController.ConvertToOther());
                            result.AddRange(trainningController.ConvertToOther());
                            break;
                    }
                }
                break;
        }
        StartCoroutine(ShowCardCoroutine(result));    
    }

    private IEnumerator ShowCardCoroutine(List<CardModel> cards)
    {
        List<GameObject> cardGOs = new();
        DeckView deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<DeckView>();
        CardModifedTray.gameObject.SetActive(true);
        foreach (var card in cards) 
        {
            var cardGO = Instantiate(cardPrefab, CardModifedTray);
            cardGO.Setup(deck.GetCardSprite(card), card);
            cardGOs.Add(cardGO.gameObject);
        }
        float elapsed = 0f;
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < cardGOs.Count; i++) 
        {
            Destroy(cardGOs[i]);
        }
        CardModifedTray.gameObject.SetActive(false);
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        GameObject deckGO = GameObject.FindGameObjectWithTag("Deck");
        if (deckGO != null)
        {
            deckGO.GetComponent<DeckView>().ShowDeck();
        }
        UpDateTrainingAmount();
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