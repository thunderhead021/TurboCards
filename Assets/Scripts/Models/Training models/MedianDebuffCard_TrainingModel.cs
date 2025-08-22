public class MedianDebuffCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(-2);
    }
}

public class MedianDebuffPlayerCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(-2);
    }
}