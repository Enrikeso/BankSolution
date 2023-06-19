namespace BankConsole;

public abstract class Person
{
    public abstract string GetName();

    public string GetContry()
    {
        return "Mexico";
    }
}

public interface IPerson
{
    string GetName();

    string GetContry();
}