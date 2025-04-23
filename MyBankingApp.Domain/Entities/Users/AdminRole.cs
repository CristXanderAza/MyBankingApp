
namespace MyBankingApp.Domain.Entities.Users
{
    public enum AdminRole
    {
        SuperAdmin,     // acceso total
        AccountManager, // manejo de clientes y cuentas
        LoanOfficer,    // manejo de préstamos
        Auditor         // solo lectura, para revisión
    }
}
