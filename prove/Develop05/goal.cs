abstract class Goal
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
}
