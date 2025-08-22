using System.Collections.Generic;

public class RaceController
{
    private readonly List<(RaceUnitModel unit, int currentPostion)> units = new();

    private int Goal = 2;

    public RaceController() 
    {
        ResetRace();
    }

    public void SetGoal(int goal)
    {
        ResetRace();
        this.Goal = goal; 
    }

    public void ResetRace() 
    {
        units.Clear();
        units.Add((new RaceUnitModel((Suit)0, 1), 0));
        units.Add((new RaceUnitModel((Suit)1, 1), 0));
        units.Add((new RaceUnitModel((Suit)2, 1), 0));
        units.Add((new RaceUnitModel((Suit)3, 1), 0));
    }

    public bool MovingToGoal(Suit suit, int value) 
    {
        bool someoneTouchGoal = false;
        switch (suit) 
        {
            case (Suit)0:
                var unit0 = units[0];
                unit0.currentPostion += value;
                if (unit0.currentPostion >= Goal - 1 )
                {
                    someoneTouchGoal = true;
                    unit0.currentPostion = Goal - 1;
                }
                units[0] = unit0;
                break;
            case (Suit)1:
                var unit1 = units[1];
                unit1.currentPostion += value;
                if (unit1.currentPostion >= Goal - 1 )
                {
                    someoneTouchGoal = true;
                    unit1.currentPostion = Goal - 1;
                }
                units[1] = unit1;
                break;
            case (Suit)2:
                var unit2 = units[2];
                unit2.currentPostion += value;
                if (unit2.currentPostion >= Goal - 1 )
                {
                    someoneTouchGoal = true;
                    unit2.currentPostion = Goal - 1;
                }
                units[2] = unit2;
                break;
            case (Suit)3:
                var unit3 = units[3];
                unit3.currentPostion += value;
                if (unit3.currentPostion >= Goal - 1 )
                {
                    someoneTouchGoal = true;
                    unit3.currentPostion = Goal - 1;
                }
                units[3] = unit3;
                break;
        }

        return someoneTouchGoal;
    }

    public int GetTheHighestCurrentPos() 
    {
        int result = 0;

        foreach (var unit in units) 
        {
            if (unit.currentPostion >= result)
                result = unit.currentPostion;
        }

        return result;
    }

    public int GetUnitPostion(Suit suit) 
    {
        return suit switch
        {
            (Suit)0 => units[0].currentPostion,
            (Suit)1 => units[1].currentPostion,
            (Suit)2 => units[2].currentPostion,
            (Suit)3 => units[3].currentPostion,
            _ => -1,
        };
    }
}
