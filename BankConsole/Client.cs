namespace BankConsole;

public class Client: User, IPerson
{
    public char TaxRegime { get; set; }

    public Client() {}

    public Client (int ID,string Name, string Email, decimal Balance, char TaxRegime) : base(ID, Name, Email, Balance)
    {
        this.TaxRegime = TaxRegime;
        SetBalance(Balance);
    }

    public override void SetBalance(decimal amout)
    {
        base.SetBalance(amout);

        if(TaxRegime.Equals("M"))
            Balance += (amout * 0.02m);
    }

    public override string ShowData()
    {
        return base.ShowData() + $", Regimen Fiscal: {this.TaxRegime}";
    }

    public string GetName()
    {
        return Name;
    }

    public string GetContry()
    {
        return "Mexico";
    }
}
