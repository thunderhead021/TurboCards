using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    public GameObject deckGrid;
    public GameObject cardPrefab;
    public List<Sprite> cardImagesSuit0;
    public List<Sprite> cardImagesSuit1;
    public List<Sprite> cardImagesSuit2;
    public List<Sprite> cardImagesSuit3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TrainingManager.Instance.ResetTrainingAmount();
        ShowDeck();
    }

    public void ShowDeck() 
    {
        foreach (Transform child in deckGrid.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var card in DeckController.Instance.ReadOnlyDeck)
        {
            GameObject cardView = Instantiate(cardPrefab, deckGrid.transform);
            cardView.GetComponent<CardView>().Setup(GetCardSprite(card), card);
        }
    }

    public Sprite GetCardSprite(CardModel card) 
    {
        Sprite result = null;
        switch (card.GetSuit()) 
        {
            case (Suit)0:
                result = cardImagesSuit0[card.GetCardValue() - 1];
                break;
            case (Suit)1:
                result = cardImagesSuit1[card.GetCardValue() - 1];
                break;
            case (Suit)2:
                result = cardImagesSuit2[card.GetCardValue() - 1];
                break;
            case (Suit)3:
                result = cardImagesSuit3[card.GetCardValue() - 1];
                break;
        }

        return result;
    }

}
