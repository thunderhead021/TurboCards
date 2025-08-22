using System;

public class RaceUnitModel
{
    private Suit RaceUnitSuit = (Suit)0;

    private int RaceUnitValue = 1;

    public Suit GetSuit() => RaceUnitSuit;

    public int Value => RaceUnitValue;

    public void ModifyValue(int modifier) 
    {
        RaceUnitValue += modifier;
        Math.Clamp(RaceUnitValue, 1, 13);
    }

    public void ModifySuit(Suit suit) 
    {
        RaceUnitSuit = suit;
    }

    public RaceUnitModel(Suit suit, int value)
    {
        RaceUnitSuit = suit;
        RaceUnitValue = value;
        Math.Clamp(RaceUnitValue, 1, 13);
    }
}
