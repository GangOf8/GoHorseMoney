using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.UseCase;

namespace HorseMoney.Domain.Interfaces.WalletInterfaces
{
    public interface IGetAllAsyncWalletUseCase : IUseCaseBase<PageableDto, BasicResult<List<WalletDto>>>
    {
    }
}
