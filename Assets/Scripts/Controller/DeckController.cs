using System;
using System.Linq;
using Random = System.Random;

public class DeckController
{
    public static DeckController Instance { get; private set; }
    private Suit PlayerSuit = (Suit)0;
    public CardModel[] Deck = new CardModel[52];
    public CardModel[] ReadOnlyDeck = new CardModel[52];
    public int currentIndex = 0;

    public DeckController() 
    {
        for (int suit = 0; suit < 4; suit++) 
        {
            for (int i = 1; i <= 13; i++)
            {
                CardModel card = new((Suit)suit, i, currentIndex);
                AddCard(card);
            }
        }
        
        currentIndex = 0;
        Deck = ReadOnlyDeck;
        Instance = this;
    }

    public void UpdateCard(CardModel card) 
    {
        Instance.ReadOnlyDeck[card.GetId()] = card;
    }

    public void SetPlayerSuit(Suit suit) => PlayerSuit = suit;

    public void Shuffle() 
    {
        Random rng = new();
        Deck = new CardModel[52];
        Array.Copy(ReadOnlyDeck, Deck, ReadOnlyDeck.Length);
        for (int i = 51; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (Deck[i], Deck[j]) = (Deck[j], Deck[i]); 
        }
    }

    public CardModel GetARandomCard(Suit fromSuit) 
    {
        CardModel result = null;
        Random rng = new();
        var suit = ReadOnlyDeck.Where(x => x.GetSuit() == fromSuit).ToArray();
        if (suit.Length > 0)
        {
            result = suit[rng.Next(suit.Length)];
        }

        return result;
    }

    public CardModel GetARandomCardExclude(Suit fromSuit)
    {
        CardModel result = null;
        Random rng = new();
        CardModel[] suit = ReadOnlyDeck.Where(x => x.GetSuit() != fromSuit).ToArray();
        if (suit.Length > 0)
        {
            result = suit[rng.Next(suit.Length)];
        }

        return result;
    }

    public CardModel GetARandomCardExclude()
    {
        CardModel result = null;
        Random rng = new();
        CardModel[] suit = ReadOnlyDeck.Where(x => x.GetSuit() != PlayerSuit).ToArray();
        if (suit.Length > 0)
        {
            result = suit[rng.Next(suit.Length)];
        }

        return result;
    }

    public CardModel GetARandomCardFromPlayerSuit()
    {
        CardModel result = null;
        Random rng = new();
        var suit = ReadOnlyDeck.Where(x => x.GetSuit() == PlayerSuit).ToArray();
        if (suit.Length > 0)
        {
            result = suit[rng.Next(suit.Length)];
        }

        return result;
    }

    public void SetCardModel(CardModel newCard) 
    {
        ReadOnlyDeck[newCard.GetId()] = newCard;
    }

    public CardModel GetNextCardFromDeck() 
    {
        CardModel result = Deck[currentIndex];
        currentIndex++;
        if (currentIndex == Deck.Length) 
        {
            currentIndex = 0;
            Shuffle();
        }
        return result;
    }

    private void AddCard(CardModel card) 
    {
        ReadOnlyDeck[currentIndex] = card;
        currentIndex++;
    }
}
