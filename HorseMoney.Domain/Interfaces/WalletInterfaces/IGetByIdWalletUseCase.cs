using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;

namespace HorseMoney.Domain.Interfaces.WalletInterfaces
{
    public interface IGetByIdWalletUseCase : IUseCaseBase<Guid, BasicResult<WalletDto>>
    {
    }
}
