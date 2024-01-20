using HorseMoney.Application.UseCase.CategoryUseCase;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;
using HorseMoney.Domain.Interfaces.Wallet;
using Microsoft.Extensions.DependencyInjection;
using HorseMoney.Domain.Interfaces.WalletInterfaces;

namespace HorseMoney.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IDeleteWalletUseCase, DeleteWalletUseCase>();
        services.AddScoped<IGetAllAsyncWalletUseCase, GetAllAsyncWalletUseCase>();
        services.AddScoped<IGetByIdWalletUseCase, GetByIdWalletUseCase>();
        services.AddScoped<IUpdateWalletUseCase, UpdateWalletUseCase>();

        return services;
    }
}