namespace iTrendz.Domain.Fakers;

public class UniqueIdGenerator
{
    private int _currentId = 1;
    public int GetNextId() => _currentId++;
}