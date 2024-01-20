using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;

namespace HorseMoney.Domain.Interfaces.WalletInterfaces
{
    public interface IDeleteWalletUseCase : IUseCaseBase<Guid, BasicResult>
    {
    }
}
