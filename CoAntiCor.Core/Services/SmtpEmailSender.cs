//using CoAntiCor.Core.Notifications;
using CoAntiCor.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CoAntiCor.Core.Services;

public class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _config;

    public SmtpEmailSender(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        var host = _config["Email:Smtp:Host"];
        var port = int.Parse(_config["Email:Smtp:Port"] ?? "25");
        var user = _config["Email:Smtp:User"];
        var pass = _config["Email:Smtp:Pass"];
        var from = _config["Email:From"];

        using var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(user, pass),
            EnableSsl = true
        };

        var mail = new MailMessage(from!, to, subject, body) { IsBodyHtml = true };
        await client.SendMailAsync(mail);
    }

    Task IEmailSender.SendAsync(string to, string subject, string body)
    {
        throw new NotImplementedException();
    }

    Task IEmailSender.SendAsync(object email, string v1, string v2)
    {
        throw new NotImplementedException();
    }
}
