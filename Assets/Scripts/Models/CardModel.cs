using System;

public class CardModel
{
    private Suit CardSuit = (Suit)0;

    private int CardValue = 1;

    private readonly int id = -1;

    public int GetId() => id;

    public Suit GetSuit() => CardSuit;

    public int GetCardValue() => CardValue;

    public void ModifyValue(int modifier)
    {
        CardValue += modifier;

        if(CardValue > 13)
            CardValue = 13;
        else if (CardValue < 1)
            CardValue = 1;
    }

    public void ModifySuit(Suit suit)
    {
        CardSuit = suit;
    }

    public CardModel(Suit suit, int cardValue, int id) 
    {
        CardSuit = suit;
        CardValue = cardValue;
        Math.Clamp(CardValue, 1, 13);
        this.id = id;
    }
}


public enum Suit 
{
    Heart = 0,
    Diamond = 1,
    Club = 2,
    Spade = 3,
}
