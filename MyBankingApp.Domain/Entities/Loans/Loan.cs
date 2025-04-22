using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.Transactions;

namespace MyBankingApp.Domain.Entities.Loans
{
    public class Loan
    {
        public Guid LoanID { get; private set; }
        public Guid AccountID { get; private set; }
        public decimal PrincipalAmount { get; private set; }
        public decimal InterestRate { get; private set; }
        public int TermInMonths { get; private set; }
        public DateTime StartDate { get; private set; }

        public decimal OutstandingBalance { get; private set; }

        public virtual AccountBase Account { get; private set; }
        public virtual ICollection<LoanPayment> Payments { get; private set; } = new List<LoanPayment>();

        // Puedes agregar métodos para:
        // - Calcular intereses
        // - Calcular cuota mensual
        // - Generar cronograma de pagos
        // - Aplicar pagos
    }
}
