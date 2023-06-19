namespace BankConsole;

public class Employee : User, IPerson 
{
    public string Department { get; set; }

    public Employee() {}

    public Employee (int ID,string Name, string Email, decimal Balance, string Department) : base(ID, Name, Email, Balance)
    {
        this.Department = Department;
        SetBalance(Balance);
    }

    public override void SetBalance(decimal amout)
    {
        base.SetBalance(amout);

            if(Department.Equals("IT"))
                Balance += (amout * 0.05m);
    }

    public override string ShowData()
    {
        return base.ShowData() + $", Regimen Fiscal: {this.Department}";
    }

    public string GetName()
    {
        return Name + "!";
    }

    public string GetContry()
    {
        return "Mexico";
    }
}