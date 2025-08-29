using System.Collections.Generic;

public class ConvertCardToPlayer_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifySuit(DeckController.Instance.GetPlayerSuit());
        return new List<CardModel>() { Card };
    }
}

public class ConvertCardToEnemy_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifySuit(DeckController.Instance.GetARandomNonPlayerSuit());
        return new List<CardModel>() { Card };
    }
}

public class SwapCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel playerCard = DeckController.Instance.GetARandomCardFromPlayerSuit();
        CardModel otherCard = DeckController.Instance.GetARandomCardExclude();

        playerCard.ModifySuit(otherCard.GetSuit());
        otherCard.ModifySuit(DeckController.Instance.GetPlayerSuit());
        return new List<CardModel>() { playerCard, otherCard };
    }
}

