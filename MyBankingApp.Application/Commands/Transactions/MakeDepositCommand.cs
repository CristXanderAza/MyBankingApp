using AutoMapper;
using MediatR;
using MyBankingApp.Application.DTOs.Transactions;
using MyBankingApp.Application.Features;
using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.Transactions;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class MakeDepositCommand : IRequest<Result<BankTransactionDTO>>, ITransactionalCommand
    {
        public Guid AccountID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } 
    }

    public class MakeDepositCommandHandler : IRequestHandler<MakeDepositCommand, Result<BankTransactionDTO>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public MakeDepositCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Result<BankTransactionDTO>> Handle(MakeDepositCommand request, CancellationToken cancellationToken)
        {
            AccountBase account = await _accountRepository.GetByIdAsync(request.AccountID);
            if (account == null)
                Result<BankTransactionDTO>.Fail("Account not found.");
            if (!account.CanDeposit(request.Amount))
                return Result<BankTransactionDTO>.Fail("Deposit amount exceeds account limit.");
            var transaction = new BankTransaction(TransactionTypes.Deposit, null, request.Amount, request.Description, request.AccountID);
            if (!account.AddIngress(transaction))
                return Result<BankTransactionDTO>.Fail("Failed to add transaction to account.");
            await _accountRepository.UpdateAsync(account);
            BankTransactionDTO transactionDTO = _mapper.Map<BankTransactionDTO>(transaction);
            return Result<BankTransactionDTO>.Success(transactionDTO);
        }
    }
}
