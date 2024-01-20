using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.Categories;
using HorseMoney.Domain.Entities;

namespace HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;

public interface ICreateCategoryUseCase : IUseCaseBase<CreateCategoryDto, BasicResult>
{
}