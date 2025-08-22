public class SmallBuffCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(1);
    }
}

public class SmallBuffEnemyCard_TrainingModel : TrainingModel
{
    public override void Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(1);
    }
}