using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrencyWallet.Service.Interfaces
{
    public interface ICurrencyServices
    {
        void GetInfoAboutAllCurrencies();

        void GetInfoAboutCurrencyByShortName();
    }
}
