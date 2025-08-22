public class MedianBuffCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(2);
    }
}

public class MedianBuffEnemyCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(2);
    }
}
