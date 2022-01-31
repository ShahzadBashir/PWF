using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Services.Stripe
{
    public class StripeService:IStripeService
    {

        public async Task<bool> PayAsync()
        {
            //Change 
            StripeConfiguration.ApiKey = "sk_test_51KNtcNLCk2mbFIPwRVvuoO8kSk3HXVywkV1lqYCbJBgyFtzKUhmp7lesXAVe57H06vHcrBp6cAaCwdZadPkIP8Ak00LsUX0d4e";
            var options = new TokenCreateOptions
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
            await service.CreateAsync(options);

            var chargeOptions = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "usd",
                Source = "tok_visa",
                Description = "My First Test Charge (created for API docs)",
            };
            var chargeService = new ChargeService();
            Charge x= await chargeService.CreateAsync(chargeOptions);
            if (x.Paid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
