using MailKit.Net.Smtp;
using MimeKit;

namespace BankConsole;

public static class EmialService
{
    public static void SendMail()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Carlos Castillo", "carlos2323@gmail.com"));
        message.To.Add(new MailboxAddress("Admin","carloscastillo.enri@gmail.com"));
        message.Subject = "BankConsole: Usuarios nuevos.";

        message.Body = new TextPart("plain") {
            Text = GetEmailText()
        };

        using (var client = new SmtpClient()) {
            client.Connect("stm.gmail.com", 587, false);
            client.Authenticate("carlos2323@gmail.com", "1111111111111111");
            client.Send(message);
            client.Disconnect(true);
        }
    }

    private static string GetEmailText()
    {
        List<User> newUsers = Storage.GetNewNumbers();

        if(newUsers.Count == 0)
            return "No hay usuarios nuevos.";
        string emailText = "Usuarios agregados hoy: \n";

        foreach (User user in newUsers)
            emailText += "\t " + user.ShowData() + "\n";

        return emailText;
    }
}