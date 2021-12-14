using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestePagCerto.Infrastructure.Dtos.Payment
{
    public class ReadPaymentDto
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public DateTime PaitAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public decimal Amount { get; set; }
        public decimal BankSlip { get; set; }
        public decimal CardTransaction { get; set; }

    }
}
