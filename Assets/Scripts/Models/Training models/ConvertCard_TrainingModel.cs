public class ConvertCardToPlayer_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifySuit(DeckController.Instance.GetPlayerSuit());
    }
}

public class ConvertCardToEnemy_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifySuit(DeckController.Instance.GetARandomNonPlayerSuit());
    }
}

public class SwapCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel playerCard = DeckController.Instance.GetARandomCardFromPlayerSuit();
        CardModel otherCard = DeckController.Instance.GetARandomCardExclude();

        playerCard.ModifySuit(otherCard.GetSuit());
        otherCard.ModifySuit(DeckController.Instance.GetPlayerSuit());
    }
}

