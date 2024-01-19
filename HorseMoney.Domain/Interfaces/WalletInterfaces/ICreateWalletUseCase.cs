using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;

namespace HorseMoney.Domain.Interfaces.Wallet
{
    public interface ICreateWalletUseCase : IUseCaseBase<WalletDto, BasicResult>
    {
    }
}
