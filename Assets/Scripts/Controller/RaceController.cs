using System.Collections.Generic;

public class RaceController
{
    public static RaceController Instance { get; private set; }

    private readonly List<(RaceUnitModel unit, int currentPostion)> units = new();

    private int Goal = 2;

    private int[][] RaceTrack = new int[4][];

    private int[][] SuitBuff = new int[4][];

    public int[][] GetSuitBuff() => SuitBuff;

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

        SuitBuff[0] = new int[2];
        SuitBuff[1] = new int[2];
        SuitBuff[2] = new int[2];
        SuitBuff[3] = new int[2];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                SuitBuff[i][j] = 0;
            }
        }
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
                switch (skill.skillActivationType) 
                {
                    case SkillActivationType.Trap:
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
                        break;
                    case SkillActivationType.Effect:
                        skill.EffectAction(out int effectModifier, out int effectModifyAmount, suit);
                        if (skill.EffectSuit != null) 
                        {
                            SuitBuff[(int)skill.EffectSuit][0] = effectModifier;
                            SuitBuff[(int)skill.EffectSuit][1] = effectModifyAmount;
                        }
                        break;
                    case SkillActivationType.Active:
                        skill.ActiveAction(out int activeValue, suit);
                        if (skill.EffectSuit != null)
                        {
                            var effectedUnit = units[(int)skill.EffectSuit];
                            effectedUnit.currentPostion += activeValue;
                            units[(int)skill.EffectSuit] = effectedUnit;
                        }
                        break;
                }                
            }
        }
        bool someoneTouchGoal = false;
        int modifyValue = value;
        for (int i = currentPosition; i <= currentPosition + value; i++) 
        {
            if(i > Goal - 1)
                break;
            modifyValue += RaceTrack[(int)suit][i];
            RaceTrack[(int)suit][i] = 0;
        }

        if (SuitBuff[(int)suit][1] > 0) 
        {
            modifyValue += SuitBuff[(int)suit][0];
            SuitBuff[(int)suit][1]--;
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
