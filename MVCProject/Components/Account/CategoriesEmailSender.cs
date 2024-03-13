using System.Net;
using System.Net.Mail;

namespace MVCProject.Components.Account;

// Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
public class CategoriesEmailSender : ICategoriesEmailSender
{
    // private readonly IEmailSender _emailSender = new NoOpEmailSender();
    //
    // public Task SendConfirmationLinkAsyn(ApplicationUser user, string email, string confirmationLink) =>
    //     _emailSender.SendEmailAsync(email, "Confirm your email",
    //         $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
    //
    // public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
    //     _emailSender.SendEmailAsync(email, "Reset your password",
    //         $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
    //
    // public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
    //     _emailSender.SendEmailAsync(email, "Reset your password",
    //         $"Please reset your password using the following code: {resetCode}");

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var mail = "matheusventureli50@gmail.com";
        var password = "nox1342Zm*1234";

        var client = new SmtpClient("smtp-mail.outlook.com", 631)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, password)
        };

        return client.SendMailAsync(new MailMessage(from: mail, to: email, subject, message));
    }
}