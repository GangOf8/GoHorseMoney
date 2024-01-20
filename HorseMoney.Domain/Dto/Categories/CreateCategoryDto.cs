using HorseMoney.Domain.Enums;

namespace HorseMoney.Domain.Dto.Categories;

public record CreateCategoryDto(
    string Name,
    Guid UserId,
    ECategoryType Type);