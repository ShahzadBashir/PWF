using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PWF.Services.Models;
using Stripe;
namespace PWF.Services.PaymentGateway
{
    public class StripeService : IStripeService
    {

        public async Task<string> CreateaCharge()//Card card, Customer customer, Charge charge)
        {
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";//todo move to constants/json

            //todo -send objects instead of hard code values
            try
            {
                var tokenCreateOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = "4242424242424242",
                        ExpMonth = 1,
                        ExpYear = 2023,
                        Cvc = "314",
                    },
                };
                var service = new TokenService();
                var token = service.Create(tokenCreateOptions)?.Id;

                var chargeCreateOptions = new ChargeCreateOptions
                {
                    Amount = 2000,
                    Currency = "usd",
                    Source = token,
                    Description = "Vikash Test",
                };
                var service5 = new ChargeService();
                var op1 = service5.Create(chargeCreateOptions);
                var op = JsonConvert.SerializeObject(op1, Formatting.Indented);
                return op;
            }
            catch (Exception e)
            {

            }
            return "";
        }

    }
}
