using UnityEngine;
using UnityEngine.UI;

public class TrainingUIView : MonoBehaviour
{
    public Slider RemainTurn;

    public void UpdateRemainTurn(int turn) 
    {
        RemainTurn.value = turn;
    }
}
