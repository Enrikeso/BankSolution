using Newtonsoft.Json;

namespace BankConsole;

public class User
{
    [JsonProperty]
    protected int ID { get; set; }
    [JsonProperty]
    protected string Name { get; set;} 
    [JsonProperty]
    protected string Email { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }
/*
    public virtual User()
    {
        this.Balance =1000;
    }
*/

    public User() {}

    public User(int ID,string Name, string Email, decimal Balance)
    {
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        //SetBalance(Balance);
        this.RegisterDate = DateTime.Now;
    }
    
    public int GetID()
    {
        return ID;
    }

    public DateTime GetRegisterDate()
    {
        return RegisterDate;
    }

    public virtual void SetBalance(decimal amout)
    {
        decimal quantity = 0;
        
        if(amout < 0)
           quantity = 0;
        else 
            quantity = amout;
        this.Balance += quantity;
    }

    public virtual string ShowData()
    {
        return $"ID: {this.ID}, Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de registro:{this.RegisterDate.ToShortDateString()}";
    }
    public string ShowData(string initialMessage)
    {
        return $"{initialMessage} -> Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de registro:{this.RegisterDate}";
    }

    /*
    public override string GetName()
    {
        return Name;
    }
    */
}