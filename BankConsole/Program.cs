using BankConsole;
using System.Text.RegularExpressions;

int ID;
string Email;
decimal Balance;
char userType;
char TaxRegime;
string text;
bool past;

if(args.Length == 0)
    EmialService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opcion:");
    Console.WriteLine("1 - Crear un Usuario nuevo.");
    Console.WriteLine("2 - Eliminar un Usuario exitaente.");
    Console.WriteLine("3 - Salir.");

    int opcion = 0;
    do{
        string imput = Console.ReadLine();

        if(!int.TryParse(imput, out opcion))
            Console.WriteLine("Debe ingresar un numrto (1, 2 o 3).");
        else if (opcion > 3)
            Console.WriteLine("Debes imgresar un numero valido (1, 2 o 3).");

    }while(opcion == 0 || opcion > 3);

    switch(opcion)
    {
        case 1:
            CreateUser();
        break;

        case 2:
            DeleteUser();
        break;

        case 3:
            Environment.Exit(0);
        break;
    }
}

void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Ingresa la informacion del usuario: ");

    do{
        past = false;
        Console.WriteLine("ID: ");
        text = Console.ReadLine();
        if(!int.TryParse(text, out ID))
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else if(ID < 0)
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else if(Storage.EncontrarID(text) != null)
            Console.WriteLine("Ingrese un valor que no este repetido.");
        else
            past = true;
    }while(past == false);

    Console.WriteLine("Nombre: ");
    string name = Console.ReadLine();

    do{
        Console.WriteLine("Email: ");
        
        past = false;
        Email = Console.ReadLine();
        if(Regex.IsMatch(Email, @"^[a-zA-Z0-9]+([._][a-zA-Z0-9]+)*@gmail\.com"))
            past= true;
        else
            Console.WriteLine("Ingrese un correo electronico.");
    }while(past == false);

    do{
        past = false;
        Console.WriteLine("Saldo: ");
        string text = Console.ReadLine();
        if(!decimal.TryParse(text, out Balance))
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else if(Balance < 0)
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else 
            past = true;

    }while(past == false);
    
    do{
        past = false;
        Console.WriteLine("Escribe 'c' si el usuario es cliente, 'e' si es empleado: ");
        text = Console.ReadLine();

        if(!char.TryParse(text, out userType))
            Console.WriteLine("Ingrese un solo caracter.");
        else if(userType != 'c' && userType != 'e')
            Console.WriteLine("Debes imgresar un caracter valido (c o e).");
        else 
            past = true;
    }while(past == false);

    User newUser;

    if(userType.Equals('c'))
    {
        do{
        past = false;
        Console.Write("Regimen fiscal: ");
        text = Console.ReadLine();

        if(!char.TryParse(text, out TaxRegime))
            Console.WriteLine("Ingrese un solo caracter.");
        else 
            past = true;
        }while(past == false);

        newUser = new Client(ID, name, Email, Balance, TaxRegime);
    }
    else
    {
        Console.WriteLine("Departamento: ");
        string department = Console.ReadLine();

        newUser = new Employee (ID, name, Email, Balance, department);
    }

    Storage.AddUser(newUser);
    Console.WriteLine("Usuario creado.");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser()
{
    Console.Clear();

    do{
        past = false;
        
        Console.Write("Ingresa el ID del usuario a eliminar: ");
        text = Console.ReadLine();

        if(!int.TryParse(text, out  ID))
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else if(ID < 0)
            Console.WriteLine("Ingrese un valor numerico positivo.");
        else if(Storage.EncontrarID(text) == null)
            Console.WriteLine("Ingrese un ID que este en los datos.");
        else
            past = true;
    }while(past == false);

    string result = Storage.DeleteUser(ID);

    if(result.Equals("Success"))
    {
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    }
}
/*
Client james = new Client(1, "James", "james@gmail.com", 4000, 'M');

james.ID = 1;
james.Name = "James";
james.Email = "james@gmail.com";
james.RegisterDate = DateTime.Now;


james.SetBalance(2000);

Console.WriteLine(james.ShowData());

Storage.AddUser(james);


Employee ximena = new Employee(2, "Ximena", "Ximena@gmail.com", 4000, "IT");

Storage.AddUser(james);

Storage.AddUser(ximena);

Console.WriteLine(ximena.ShowData());
*/