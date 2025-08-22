public abstract class TrainingModel
{
    private static int _nextId = 0;   
    public int Id { get; private set; }

    protected TrainingModel()
    {
        Id = _nextId++;
    }

    public abstract void Action();
}
