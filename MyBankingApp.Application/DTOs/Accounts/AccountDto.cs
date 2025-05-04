using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.Application.DTOs.Accounts
{
    public class AccountDto
    {
        public Guid AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        // Puedes agregar más propiedades según sea necesario
    }
}
