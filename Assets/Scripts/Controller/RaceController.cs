using System;
using System.Collections.Generic;

public class RaceController
{
    public static RaceController Instance { get; private set; }

    private readonly List<(RaceUnitModel unit, int currentPostion)> units = new();

    private int Goal = 2;

    private int[][] RaceTrack = new int[4][];

    public RaceController() 
    {
        ResetRace();
        Instance = this;
    }

    public void SetGoal(int goal)
    {
        ResetRace();
        this.Goal = goal;
        RaceTrack = new int[4][];
        RaceTrack[0] = new int[goal];
        RaceTrack[1] = new int[goal];
        RaceTrack[2] = new int[goal];
        RaceTrack[3] = new int[goal];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < goal; j++)
            {
                RaceTrack[i][j] = 0;
            }
        }
    }

    public void ResetRace() 
    {
        units.Clear();
        units.Add((new RaceUnitModel((Suit)0, 1), 0));
        units.Add((new RaceUnitModel((Suit)1, 1), 0));
        units.Add((new RaceUnitModel((Suit)2, 1), 0));
        units.Add((new RaceUnitModel((Suit)3, 1), 0));
    }

    public bool MovingToGoal(CardModel cardModel) 
    {
        Suit suit = cardModel.GetSuit();
        int value = cardModel.GetCardValue();
        List<CardSkillModel> skills = cardModel.GetCardSkills();
        int currentPosition = units[(int)suit].currentPostion;
        if ( skills.Count > 0) 
        {
            foreach (var skill in skills) 
            {
                if (skill.skillActivationType == SkillActivationType.Trap) 
                {
                    skill.TrapAction(currentPosition, out int effectPosition, out int effectValue, suit);
                    if (effectPosition >= 0 && effectPosition < Goal)
                    {
                        if (skill.EffectSuit != null)
                        {
                            RaceTrack[(int)skill.EffectSuit][effectPosition] += effectValue;
                        }
                        else
                        {
                            RaceTrack[0][effectPosition] += effectValue;
                            RaceTrack[1][effectPosition] += effectValue;
                            RaceTrack[2][effectPosition] += effectValue;
                            RaceTrack[3][effectPosition] += effectValue;
                        }

                    }
                }    
            }
        }
        bool someoneTouchGoal = false;
        int modifyValue = value;
        for (int i = currentPosition; i <= currentPosition + value; i++) 
        {
            modifyValue += RaceTrack[(int)suit][i];
            RaceTrack[(int)suit][i] = 0;
        }
        var unit = units[(int)suit];
        unit.currentPostion += modifyValue;
        if (unit.currentPostion >= Goal - 1)
        {
            someoneTouchGoal = true;
            unit.currentPostion = Goal - 1;
        }
        units[(int)suit] = unit;
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
