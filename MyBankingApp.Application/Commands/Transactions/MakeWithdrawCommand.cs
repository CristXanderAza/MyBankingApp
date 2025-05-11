using AutoMapper;
using MediatR;
using MyBankingApp.Application.DTOs.Transactions;
using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.Transactions;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts;


namespace MyBankingApp.Application.Commands.Transactions
{
    public class MakeWithdrawCommand : IRequest<Result<BankTransactionDTO>>
    {
        public Guid AccountID { get; set; }
        public decimal Amount { get; set; }

    }
    public class MakeWithdrawCommandHandler : IRequestHandler<MakeWithdrawCommand, Result<BankTransactionDTO>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public MakeWithdrawCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Result<BankTransactionDTO>> Handle(MakeWithdrawCommand request, CancellationToken cancellationToken)
        {
            AccountBase account = await _accountRepository.GetByIdAsync(request.AccountID);
            if (account == null)
                Result<BankTransactionDTO>.Fail("Account not found");
            if(!account.CanWithdraw(request.Amount))
                return Result<BankTransactionDTO>.Fail("Withdraw amount exceeds account balance.");
            BankTransaction transaction = new BankTransaction(TransactionTypes.Withdraw, request.AccountID, request.Amount, null, null);
            if (!account.AddEgress(transaction))
                return Result<BankTransactionDTO>.Fail("Failed to add transaction to account.");
            await _accountRepository.UpdateAsync(account);
            BankTransactionDTO transactionDTO = _mapper.Map<BankTransactionDTO>(transaction);
            return Result<BankTransactionDTO>.Success(transactionDTO);
        }
    }
}
