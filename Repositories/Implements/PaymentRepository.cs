using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MealHuntContext _context;

        public PaymentRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<string> AddPayment(Payment payment)
        {
            try
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();  

                return payment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsExistedByTransactionId(string transactionId)
        {
            try
            {
                return await _context.Payments.AnyAsync(p => p.TransactionId.Equals(transactionId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
