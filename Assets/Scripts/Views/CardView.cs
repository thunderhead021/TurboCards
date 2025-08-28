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

    [HideInInspector]
    public CardModel CardModel;

    public void Setup(Sprite sprite, CardModel cardModel) 
    {
        CardImage.sprite = sprite;
        CardModel = cardModel;
        BufSkillProgres.gameObject.SetActive(false);
        DebufSkillProgres.gameObject.SetActive(false);

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
        }
    }
}
