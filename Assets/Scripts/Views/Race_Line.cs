using System.Collections.Generic;
using UnityEngine;

public class Race_Line : MonoBehaviour
{
    public List<Race_Checkpoint> checkPoints;

    public void Setup(float yPos) 
    {
        checkPoints[0].checkPointPos = new Vector2(-195, yPos);
        checkPoints[1].checkPointPos = new Vector2(-65 , yPos);
        checkPoints[2].checkPointPos = new Vector2(65  , yPos);
        checkPoints[3].checkPointPos = new Vector2(195 , yPos);
    }

    public Vector2 GetChildPos(Suit suit) 
    {
        return suit switch
        {
            ((Suit)0) => checkPoints[0].checkPointPos,
            ((Suit)1) => checkPoints[1].checkPointPos,
            ((Suit)2) => checkPoints[2].checkPointPos,
            ((Suit)3) => checkPoints[3].checkPointPos,
            _ => throw new System.NotImplementedException(),
        };
    }
}
