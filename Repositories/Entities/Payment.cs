using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Entities
{
    public class Payment
    {
        public string Id { get; set; }

        public double Amount { get; set; }

        public DateTime PayDate { get; set; }

        public string TransactionId {  get; set; }
        
        public int? UserId {  get; set; }
        
        public virtual User? User { get; set; }
    }
}
