using FluentValidation;
using HorseMoney.Domain.Dto.WalletDto;

namespace HorseMoney.Application.UseCase.WalletCase.Validators
{
    public class CreateWalletValidator : AbstractValidator<WalletCreateDto>
    {
        public CreateWalletValidator() {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is mandatory")
                .MinimumLength(1).WithMessage("Size is smaller than allowed. Size allowed 1");
        }
    }
}
