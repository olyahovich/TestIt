using System.Threading.Tasks;

namespace TestIT.Web.Api
{
    public interface IEmailSender
        {
            Task SendEmailAsync(string email, string subject, string htmlMessage, string textMessage = null);
        }
}