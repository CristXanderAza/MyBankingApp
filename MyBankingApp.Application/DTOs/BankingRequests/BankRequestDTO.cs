using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.Application.DTOs.BankingRequests
{
    public class BankRequestDTO
    {
        public Guid RequestID { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string RequestType {  get; set; } 
        public string Status { get; set; }
        public string? RequestComments { get; set; }
        public string? AdminsComments { get; set; }
    }
}
