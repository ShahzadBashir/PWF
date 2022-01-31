using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWF.Services.Models;
using Stripe;
namespace PWF.Services.PaymentGateway
{
    public interface IStripeService
    {
        Task<String> CreateaCharge();// Card card, Customer customer, Charge charge);

       // Task<String> CreateaCharge(Card card, Customer customer, Charge charge
    }
}
