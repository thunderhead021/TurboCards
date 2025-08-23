using TMPro;
using UnityEngine;

public class TrainingUIView : MonoBehaviour
{
    public TextMeshProUGUI RemainTurnText;

    public void UpdateRemainTurn(int turn) 
    {
        RemainTurnText.text = turn.ToString();
    }
}
