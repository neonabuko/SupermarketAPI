namespace MVCProject.Components.Account;

public interface ICategoriesEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message);
}