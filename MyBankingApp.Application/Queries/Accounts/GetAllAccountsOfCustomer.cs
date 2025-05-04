using AutoMapper;
using MediatR;
using MyBankingApp.Application.DTOs.Accounts;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts;

namespace MyBankingApp.Application.Queries.Accounts
{
    public class GetAllAccountsOfCustomerQuery : IRequest<IEnumerable<AccountDto>>
    {
        public Guid CustomerId { get; set; }
    }

    public class GetAllAccountsOfCustomerQueryHandler : IRequestHandler<GetAllAccountsOfCustomerQuery, IEnumerable<AccountDto>>
    {   
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAllAccountsOfCustomerQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsOfCustomerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AccountBase> accounts = await _accountRepository.GetAccountsByCustomerIdAsync(request.CustomerId);
            if (accounts == null || !accounts.Any())
            {
                return Enumerable.Empty<AccountDto>();
            }

            IEnumerable<AccountDto> accountDtos = accounts.Select(a => _mapper.Map<AccountDto>(a));
            return accountDtos;
        }
    }
}
