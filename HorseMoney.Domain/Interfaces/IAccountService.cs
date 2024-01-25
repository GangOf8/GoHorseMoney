using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.Account;

namespace HorseMoney.Domain.Interfaces;

public interface IAccountService
{
    Task<(Result Result, string UserId)> RegisterAsync(IRegisterModel model);
    
    Task<BasicResult> LoginAsync(LoginDto loginDto);
}