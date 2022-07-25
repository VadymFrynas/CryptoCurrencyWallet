using System.Threading.Tasks;

namespace CryptoCurrencyWallet.Service.Interfaces
{
    public interface IEmailServices
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }
}
