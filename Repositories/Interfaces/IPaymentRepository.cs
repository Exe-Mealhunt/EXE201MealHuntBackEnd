﻿using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<string> AddPayment(Payment payment);

        Task<bool> IsExistedByTransactionId(string transactionId);
    }
}