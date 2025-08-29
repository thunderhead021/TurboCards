using UnityEngine;
using UnityEngine.UI;

public class Race_Checkpoint : MonoBehaviour
{

    public Vector2 checkPointPos = Vector2.zero;

    public Image Effect;

    public Sprite Buff;

    public Sprite Debuff;

    public void ShowEffect(int value) 
    {
        if (value == 0)
            Effect.gameObject.SetActive(false);
        else if (value > 0)
        {
            Effect.gameObject.SetActive(true);
            Effect.sprite = Buff;
        }
        else 
        {
            Effect.gameObject.SetActive(true);
            Effect.sprite = Debuff;
        }
    }
}
