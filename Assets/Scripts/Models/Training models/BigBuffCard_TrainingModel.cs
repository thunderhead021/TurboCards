public class BigBuffCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(3);
    }
}

public class BigBuffEnemyCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(3);
    }
}
