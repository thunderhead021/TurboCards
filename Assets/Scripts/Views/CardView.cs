using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image CardImage;

    public Slider BufSkillProgres;

    public Slider DebufSkillProgres;

    public GameObject SkillsTray;

    public Image SkillPrefab;

    public Sprite[] SkillIcons = new Sprite[12];

    public Tooltip tooltip;

    [HideInInspector]
    public CardModel CardModel;

    public void Setup(Sprite sprite, CardModel cardModel) 
    {
        CardImage.sprite = sprite;
        CardModel = cardModel;
        BufSkillProgres.gameObject.SetActive(false);
        DebufSkillProgres.gameObject.SetActive(false);
        string tooltipText = "";

        var maxValue = cardModel.GetCurrentSkillTrainingReqiredTurns();
        var currentValue = cardModel.GetSkillIsLearningProgress();
        if (cardModel.IsLearningABuffSkill != null) 
        {
            if ((bool)cardModel.IsLearningABuffSkill)
            {
                BufSkillProgres.gameObject.SetActive(true);
                BufSkillProgres.maxValue = maxValue;
                BufSkillProgres.value = currentValue;
            }
            else 
            {
                DebufSkillProgres.gameObject.SetActive(true);
                DebufSkillProgres.maxValue = maxValue;
                DebufSkillProgres.value = currentValue;
            }
        }
        foreach (var skill in cardModel.GetCardSkills()) 
        {
            var skillicon = Instantiate(SkillPrefab, SkillsTray.transform);
            skillicon.sprite = SkillIcons[skill.ID];
            tooltipText += SkillText(cardModel.GetSuit(), skill.ID);
        }

        tooltip.TooltipText = tooltipText;
        tooltip.HeaderText = HeaderText(cardModel.GetSuit(), cardModel.GetCardValue());
    }

    private string SkillText(Suit suit, int id) 
    {
        string result = "";
        string head = HeadText(suit);
        string notHead = head + "<sprite name=\"NotPlayerCard\">";

        switch (id) 
        {
            case 0:
                result = "<sprite name=\"LowBuffTrap\">: put a +1 3 spaces ahead of " + head + " to its track" + "\n";
                break;
            case 1:
                result = "<sprite name=\"LowBuffActive\">: " + head + " move up 1 space" + "\n";
                break;
            case 2:
                result = "<sprite name=\"LowBuffEffect\">: +1 to the for the next 2 " + head + " cards" + "\n";
                break;
            case 3:
                result = "<sprite name=\"HighBuffTrap\">: put a +2 3 spaces ahead of " + head + " to all tracks" + "\n";
                break;
            case 4:
                result = "<sprite name=\"HighBuffActive\">: " + head + " move up 2 spaces" + "\n";
                break;
            case 5:
                result = "<sprite name=\"HighBuffEffect\">: +2 to the for the next 3 " + head + " cards" + "\n";
                break;
            case 6:
                result = "<sprite name=\"LowDebuffTrap\">: put a -1 a space behind of " + head + " to a " + notHead + " track" + "\n";
                break;
            case 7:
                result = "<sprite name=\"LowDebuffActive\">: " + notHead + " move back 1 space" + "\n";
                break;
            case 8:
                result = "<sprite name=\"LowDebuffEffect\">: -1 to the for the next 2 " + notHead + " cards" + "\n";
                break;
            case 9:
                result = "<sprite name=\"HighDebuffTrap\">: put a -2 a space behind of " + head + " to all tracks" + "\n";
                break;
            case 10:
                result = "<sprite name=\"HighDebuffActive\">: " + notHead + " move back 2 spaces" + "\n";
                break;
            case 11:
                result = "<sprite name=\"HighDebuffEffect\">: -2 to the for the next 3 " + notHead + " cards" + "\n";
                break;
        }


        return result;
    }

    private string HeaderText(Suit suit, int value) 
    {
        string result = value.ToString() + " " + SuitText(suit);
        
        return result;
    }

    private string SuitText(Suit suit) 
    {
        string result = "";
        switch (suit)
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

    private string HeadText(Suit suit)
    {
        string result = "";
        switch (suit)
        {
            case (Suit)0:
                result = "<sprite name=\"Head0\">";
                break;
            case (Suit)1:
                result = "<sprite name=\"Head1\">";
                break;
            case (Suit)2:
                result = "<sprite name=\"Head2\">";
                break;
            case (Suit)3:
                result = "<sprite name=\"Head3\">";
                break;
        }
        return result;

    }
}
