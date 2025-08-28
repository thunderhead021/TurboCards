using UnityEngine;

public class Activity_View : MonoBehaviour
{
    [HideInInspector]
    public int difficulty = 0;
    public TrainingType trainingType;

    private void Start()
    {
        TrainingManager.Instance.minDifficulty = 0;
        switch (DeckController.Instance.GetPlayerSuit()) 
        { 
            //normal 
            case (Suit)0:
                if (trainingType == TrainingType.BufSkill || trainingType == TrainingType.DebuffSkill)
                    gameObject.SetActive(false);
                break;
            //hardworking 
            case (Suit)1:
                TrainingManager.Instance.minDifficulty = 1;
                if (trainingType == TrainingType.Debuff || trainingType == TrainingType.ConvertSuit)
                    gameObject.SetActive(false);
                break;
            //caring
            case (Suit)2:
                if (trainingType == TrainingType.Debuff || trainingType == TrainingType.DebuffSkill)
                    gameObject.SetActive(false);
                break;
            //prankster 
            case (Suit)3:
                if (trainingType == TrainingType.BufSkill || trainingType == TrainingType.Buff)
                    gameObject.SetActive(false);
                break;
        } 
    }

    public void SetDifficulty(int difficulty) 
    {
        this.difficulty = difficulty;
    }

    public void StartActivity() 
    {
        TrainingManager.Instance.StartAnActivity(difficulty, trainingType);
    }

}
