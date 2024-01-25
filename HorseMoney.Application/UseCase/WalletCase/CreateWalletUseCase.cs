using FluentValidation.Results;
using HorseMoney.Application.UseCase.Validator;
using HorseMoney.Application.UseCase.WalletCase.Validators;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class CreateWalletUseCase : ICreateWalletUseCase
    {
        private readonly IWalletRepository _walletRepository;
        private readonly CreateWalletValidator _createWalletValidator;

        public CreateWalletUseCase(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _createWalletValidator = new CreateWalletValidator();
        }

        public async Task<BasicResult> Execute(WalletCreateDto input)
        {
            ValidationResult validations = await _createWalletValidator.ValidateAsync(input);
            DefaultValidator.ValidateDto(validations);

            Wallet walletMapped = input.Adapt<Wallet>();
            await _walletRepository.Add(walletMapped);
            return BasicResult.Success();
        }
    }
}
