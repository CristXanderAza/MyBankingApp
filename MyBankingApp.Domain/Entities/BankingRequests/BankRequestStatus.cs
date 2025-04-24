using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.Domain.Entities.BankingRequests
{
    public enum  BankRequestStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
