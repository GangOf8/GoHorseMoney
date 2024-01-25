using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using HorseMoney.Domain;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;
using System.Net;
using System.Collections;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class UpdateWalletUseCase : IUpdateWalletUseCase
    {
        #region Properties

        private readonly IWalletRepository _walletRepository;
        private readonly IGetByIdWalletUseCase _getByIdWalletUseCase;

        #endregion Properties

        #region Constructor

        public UpdateWalletUseCase( IWalletRepository walletRepository,
                                    IGetByIdWalletUseCase getByIdWalletUseCase)
        {
            _walletRepository = walletRepository;
            _getByIdWalletUseCase = getByIdWalletUseCase;
        }
        
        #endregion Constructors

        public async Task<BasicResult<WalletDto>> Execute(WalletUpdateDto input)
        {
            BasicResult<WalletDto> walletDto = await _getByIdWalletUseCase.Execute(input.id);
            if (walletDto.IsFailure)
            {
                return walletDto;
            }

            WalletDto walletDto1 = walletDto.Value;
            Wallet wallet = walletDto1.Adapt<Wallet>();
            Update(input, wallet);

            await _walletRepository.Update(wallet);

            return wallet.Adapt<WalletDto>();
        }

        private BasicResult Update(WalletUpdateDto walletDto, Wallet wallet)
        {
            if (string.IsNullOrWhiteSpace(walletDto.name))
            {
                return BasicResult.Failure(new Error(HttpStatusCode.BadRequest, "Name is null or empty"));
            }

            wallet.Name = walletDto.name;
            return BasicResult.Success();
        }
    }
}
