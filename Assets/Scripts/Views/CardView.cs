using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image CardImage;

    public Slider BufSkillProgres;

    public Slider DebufSkillProgres;

    public void Setup(Sprite sprite, int maxValue, int currentValue, bool? isBuff = null) 
    {
        CardImage.sprite = sprite;
        if (isBuff != null) 
        {
            if ((bool)isBuff)
            {
                BufSkillProgres.maxValue = maxValue;
                BufSkillProgres.value = currentValue;
            }
            else 
            {
                DebufSkillProgres.maxValue = maxValue;
                DebufSkillProgres.value = currentValue;
            }
        }
    }
}
