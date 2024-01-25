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
using HorseMoney.Application.UseCase.WalletCase.Validators;
using FluentValidation.Results;
using HorseMoney.Application.UseCase.Validator;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class UpdateWalletUseCase : IUpdateWalletUseCase
    {
        #region Properties

        private readonly IWalletRepository _walletRepository;
        private readonly IGetByIdWalletUseCase _getByIdWalletUseCase;
        private readonly UpdateWalletValidator _updateWalletValidator;

        #endregion Properties

        #region Constructor

        public UpdateWalletUseCase( IWalletRepository walletRepository,
                                    IGetByIdWalletUseCase getByIdWalletUseCase)
        {
            _walletRepository = walletRepository;
            _getByIdWalletUseCase = getByIdWalletUseCase;
            _updateWalletValidator = new UpdateWalletValidator();
        }
        
        #endregion Constructors

        public async Task<BasicResult<WalletDto>> Execute(WalletUpdateDto input)
        {
            ValidationResult validations = await _updateWalletValidator.ValidateAsync(input);
            DefaultValidator.ValidateDto(validations);

            BasicResult<WalletDto> walletDto = await _getByIdWalletUseCase.Execute(input.Id);
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
            if (string.IsNullOrWhiteSpace(walletDto.Name))
            {
                return BasicResult.Failure(new Error(HttpStatusCode.BadRequest, "Name is null or empty"));
            }

            wallet.Name = walletDto.Name;
            return BasicResult.Success();
        }
    }
}
