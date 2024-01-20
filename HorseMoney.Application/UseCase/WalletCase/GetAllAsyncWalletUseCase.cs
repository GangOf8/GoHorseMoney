using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using HorseMoney.Domain.Messages;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;
using System.Net;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class GetAllAsyncWalletUseCase : IGetAllAsyncWalletUseCase
    {
        private readonly IWalletRepository _walletRepository;

        public GetAllAsyncWalletUseCase(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<BasicResult<List<WalletDto>>> Execute(PageableDto input)
        {
            List<Wallet> wallets = await _walletRepository.GetAllAsync(input.skip, input.skip * input.take);
            if (wallets.Count is 0)
            {
                return BasicResult.Failure<List<WalletDto>>(new(HttpStatusCode.NotFound, CommonMessage.NoRecordsFound));
            }
         
            return wallets.Adapt<List<WalletDto>>();
        }
    }
}
