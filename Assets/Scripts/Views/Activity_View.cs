using UnityEngine;
using UnityEngine.UI;

public class Activity_View : MonoBehaviour
{
    [HideInInspector]
    public int difficulty = 0;
    public TrainingType trainingType;
    public Image Border;
    public Tooltip Tooltip;

    [SerializeField]
    private Color easy = Color.green;
    [SerializeField]
    private Color normal = Color.yellow;
    [SerializeField]
    private Color hard = new Color(255, 131, 0, 255);
    [SerializeField]
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
        SetTooltipString(difficulty);
    }

    public void StartActivity() 
    {
        TrainingManager.Instance.StartAnActivity(difficulty, trainingType);
    }

    private void SetTooltipString(int difficulty) 
    {
        string header = "";
        string content = "";
        string pass = "<sprite name=\"Pass\">";
        string fail = "<sprite name=\"Fail\">";
        string player = GetPlayerSuit();
        string notPlayer = player + "<sprite name=\"NotPlayerCard\">";
        switch (trainingType) 
        {
            case TrainingType.Debuff:
                content = pass + ": -" + (difficulty + 1) + " to 2 " + notPlayer + "\n"
                        + fail + ": -" + (difficulty + 1) + " to " + (difficulty > 1 ? "2 " : " ") + player;
                break;
            case TrainingType.DebuffSkill:
                string debuff1 = "<sprite name=\"LowDebuff\">";
                string debuff2 = "<sprite name=\"HighDebuff\">";
                content = pass + ": +" + ( difficulty % 2 == 0 ? "1 " : "2 ") + (difficulty > 1 ? debuff2 : debuff1) + " to " + player + ", +1 " + notPlayer + "\n"
                        + fail + ": +" + ( difficulty % 2 == 0 ? "2 " : "3 ") + (difficulty > 1 ? debuff2 : debuff1) + " to " + notPlayer;
                break;
            case TrainingType.Buff:
                content = pass + ": +" + (difficulty + 1) + " to " + (difficulty == 3 ? "2 " : "1 ")  + player + " and +1 to " + (difficulty < 2 ? "2 " : (difficulty == 2 ? "3 " : "1 ")) + notPlayer + "\n"
                        + fail + ": +" + (difficulty < 2 ? "1 " : (difficulty == 2 ? "2 " : "3 ") ) + "to " + (difficulty == 1 ? "4 " : "3 ") + notPlayer;
                break;
            case TrainingType.BufSkill:
                string buff1 = "<sprite name=\"LowBuff\">";
                string buff2 = "<sprite name=\"HighBuff\">";
                content = pass + ": +" + (difficulty % 2 == 0 ? "1 " : "2 ") + (difficulty > 1 ? buff2 : buff1) + " to " + player + ", +1 " + notPlayer + "\n"
                        + fail + ": +" + (difficulty % 2 == 0 ? "2 " : "3 ") + (difficulty > 1 ? buff2 : buff1) + " to " + notPlayer;
                break;
            case TrainingType.ConvertSuit:
                switch (difficulty) 
                {
                    case 0:
                        content = pass + ": swap a " + player + " with a " + notPlayer;
                        break;
                    case 1:
                        content = pass + ": swap 2 " + player + " with 2 " + notPlayer + "\n"
                                + fail + ": convert 1 " + player + " to " + notPlayer;
                        break;
                    case 2:
                        content = pass + ": convert 1 " + notPlayer + " to " + player + "\n"
                                + fail + ": convert 1 " + player + " to " + notPlayer;
                        break;
                    case 3:
                        content = pass + ": convert 2 " + notPlayer + " to " + player + "\n"
                                + fail + ": convert 2 " + player + " to " + notPlayer;
                        break;
                }
                break;
        }
        Tooltip.TooltipText = content;
        Tooltip.HeaderText = header;
    }

    private string GetPlayerSuit() 
    {
        string result = "";    
        switch (DeckController.Instance.GetPlayerSuit()) 
        {
            case (Suit)0:
                result = "<sprite name=\"Suit0\">";
                break;
            case (Suit)1:
                result = "<sprite name=\"Suit1\">";
                break;
            case (Suit)2:
                result = "<sprite name=\"Suit2\">";
                break;
            case (Suit)3:
                result = "<sprite name=\"Suit3\">";
                break;
        }
        return result;
    }
}
