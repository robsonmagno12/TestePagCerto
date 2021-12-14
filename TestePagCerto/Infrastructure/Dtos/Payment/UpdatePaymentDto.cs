using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePagCerto.Infrastructure.Dtos.Payment
{
    public class UpdatePaymentDto
    {
        public DateTime PaitAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public decimal Amount { get; set; }
        public decimal BankSlip { get; set; }
        public decimal CardTransaction { get; set; }
    }
}
