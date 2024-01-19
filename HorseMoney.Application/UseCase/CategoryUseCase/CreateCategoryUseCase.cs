using System.Net;
using FluentValidation.Results;
using HorseMoney.Application.UseCase.CategoryUseCase.Validators;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.Categories;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.Repositories;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;
using Mapster;

namespace HorseMoney.Application.UseCase.CategoryUseCase;

public class CreateCategoryUseCase : ICreateCategoryUseCase
{
    #region Properties

    private readonly ICategoryRepository _categoryRepository;
    private readonly CreateCategoryValidator _createValidator;

    #endregion Properties

    #region Constructors

    public CreateCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        _createValidator = new CreateCategoryValidator();
    }

    #endregion Constructors

    public async Task<BasicResult> Execute(CreateCategoryDto input)
    {
        ValidationResult validations = await _createValidator.ValidateAsync(input);
        if (!validations.IsValid)
        {
            return BasicResult.Failure(HttpStatusCode.NotFound, validations.Errors);
        }

        Category categoryMapped = input.Adapt<Category>();
        await _categoryRepository.Add(categoryMapped);

        return BasicResult.Success();
    }
}