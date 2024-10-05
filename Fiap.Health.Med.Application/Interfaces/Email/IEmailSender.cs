using Fiap.Health.Med.Application.ViewModel;

namespace Fiap.Health.Med.Application.Interfaces.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailViewModel emailViewModel);
    }
}
