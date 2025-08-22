using System.Linq;
using Random = System.Random;

public class DeckController
{
    public static DeckController Instance { get; private set; }
    public CardModel[] Deck = new CardModel[52];
    public CardModel[] ReadOnlyDeck = new CardModel[52];
    public int currentIndex = 0;

    public DeckController() 
    {
        for (int i = 1; i <= 13; i++) 
        {
            CardModel heart = new((Suit)0, i, currentIndex);
            AddCard(heart);

            CardModel diamond = new((Suit)1, i, currentIndex);
            AddCard(diamond);

            CardModel club = new((Suit)2, i, currentIndex);
            AddCard(club);

            CardModel spade = new((Suit)3, i, currentIndex);
            AddCard(spade);
        }
        currentIndex = 0;
        Deck = ReadOnlyDeck;
        Instance = this;
    }

    public void Shuffle() 
    {
        Random rng = new();
        Deck = ReadOnlyDeck;
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
