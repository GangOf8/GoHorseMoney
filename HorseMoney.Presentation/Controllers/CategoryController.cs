using System.Net;
using HorseMoney.Domain.Dto.Categories;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;
using HorseMoney.Domain.Messages;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HorseMoney.Presentation.Controllers;

[Route("api/v1/[controller]")]
public class CategoryController(ICreateCategoryUseCase createCategoryUseCase) : BaseController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCategoryDto createCategory)
    {
        var result = await createCategoryUseCase.Execute(createCategory);
        return ResponseBase(HttpStatusCode.Created, result, CommonMessage.OperationSucess);
    }
}