using FluentValidation;
using HorseMoney.Domain.Dto.Categories;

namespace HorseMoney.Application.UseCase.CategoryUseCase.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Description is mandatory")
            .MinimumLength(1).WithMessage("Size is smaller than allowed. Size allowed 1");

        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("User is mandatory");
    }
}