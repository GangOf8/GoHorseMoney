using HorseMoney.Application.UseCase.CategoryUseCase;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;
using HorseMoney.Domain.Interfaces.Wallet;
using Microsoft.Extensions.DependencyInjection;

namespace HorseMoney.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();

        return services;
    }
}