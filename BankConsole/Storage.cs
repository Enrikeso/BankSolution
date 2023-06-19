using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankConsole;

public static class Storage
{
    static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\user.josn";

    public static void AddUser(User user)
    {
        string json = "", userInFile = "";

        if (File.Exists(filePath))
            userInFile = File.ReadAllText(filePath);
        var listUser = JsonConvert.DeserializeObject<List<object>>(userInFile);

        if (listUser == null)
            listUser = new List<object>();
        listUser.Add(user);

        JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented};

        json = JsonConvert.SerializeObject(listUser, settings);

        File.WriteAllText(filePath, json);
    }

    public static List<User> GetNewNumbers()
    {
        string userInFile = "";
        var listUser = new List<User>();

        if(File.Exists(filePath))
            userInFile = File.ReadAllText(filePath);

        var listObjects = JsonConvert.DeserializeObject<List<object>>(userInFile);

        if(listObjects == null)
            return listUser;

        foreach (object obj in listObjects)
        {
            User newUser;
            JObject user = (JObject)obj;

            if(user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            else
                newUser = user.ToObject<Employee>();

            listUser.Add(newUser);
        }

        var newUserList = listUser.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

        return newUserList;
    }
    public static string DeleteUser(int ID)
    {
        string usersInFile = "";
        var listUsers = new List<User>();

        if(File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);

        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if(listObjects == null)
            return "Ther is no user in this file.";
        
        foreach(object obj in listObjects)
        {
            User newUser;
            JObject user = (JObject)obj;

            if(user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            else
                newUser = user.ToObject<Employee>();

            listUsers.Add(newUser);
        }
        
        var userToDelete = listUsers.Where(user => user.GetID() == ID).Single();

        listUsers.Remove(userToDelete);

        JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        string  json = JsonConvert.SerializeObject(listUsers, settings);

        File.WriteAllText(filePath, json);

        return "Success";
    }

    public static string EncontrarID(string ID)
    {
        string datos = "";

        if(File.Exists(filePath))
            datos = File.ReadAllText(filePath);

        var Usuarios = JsonConvert.DeserializeObject<List<object>>(datos);

        if(Usuarios == null)
            return null;

        foreach(JObject usuario in Usuarios)
        {
            if (usuario.Property("ID") != null && usuario["ID"].ToString() == ID)
            return ID;

        }
        return null;

    }
}