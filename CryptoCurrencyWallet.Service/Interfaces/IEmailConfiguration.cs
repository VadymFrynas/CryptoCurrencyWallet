using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrencyWallet.Service.Interfaces
{
    public interface IEmailConfiguration
    {
        string From { get; set; }
        string SmtpServer { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
