using UnityEngine;
using UnityEngine.UI;

public class Activity_View : MonoBehaviour
{
    [HideInInspector]
    public int difficulty = 0;
    public TrainingType trainingType;
    public Image Border;

    private Color easy = Color.green;
    private Color normal = Color.yellow;
    [SerializeField]
    private Color hard = new Color(255, 131, 0, 255);
    private Color extrem = Color.red;

    private void Start()
    {
        TrainingManager.Instance.minDifficulty = 0;
        switch (DeckController.Instance.GetPlayerSuit()) 
        { 
            //normal 
            case (Suit)2:
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
            case (Suit)0:
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
        switch (difficulty) 
        {
            case 0:
                Border.color = easy;
                break;
            case 1: 
                Border.color = normal; 
                break;
            case 2:
                Border.color = hard;
                break;
            case 3:
                Border.color = extrem;
                break;
        }
    }

    public void StartActivity() 
    {
        TrainingManager.Instance.StartAnActivity(difficulty, trainingType);
    }

}
