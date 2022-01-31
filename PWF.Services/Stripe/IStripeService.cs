using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Services.Stripe
{
    public interface IStripeService
    {
        Task<bool> PayAsync();
    }
}
