using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;

namespace HorseMoney.Domain.Interfaces.WalletInterfaces
{
    public interface IUpdateWalletUseCase : IUseCaseBase<WalletUpdateDto, BasicResult<WalletDto>>
    {
    }
}
