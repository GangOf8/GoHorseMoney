using FluentValidation;
using HorseMoney.Domain.Dto.WalletDto;
using System.Data;

namespace HorseMoney.Application.UseCase.WalletCase.Validators
{
    public class UpdateWalletValidator : AbstractValidator<WalletUpdateDto>
    {
        public UpdateWalletValidator() {
            RuleFor(c => c.id)
                .NotNull().WithMessage("Id is mandatory");

            RuleFor(c => c.name)
                .NotEmpty().WithMessage("Name is mandatory")
                .MinimumLength(1).WithMessage("Size is smaller than allowed. Size allowed is 1");
        }
    }
}
