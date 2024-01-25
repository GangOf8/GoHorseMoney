using System.Configuration;
using System.Text;
using HorseMoney.Application.UseCase.CategoryUseCase;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.UseCases;
using HorseMoney.Domain.Interfaces.Wallet;
using Microsoft.Extensions.DependencyInjection;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HorseMoney.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IDeleteWalletUseCase, DeleteWalletUseCase>();
        services.AddScoped<IGetAllAsyncWalletUseCase, GetAllAsyncWalletUseCase>();
        services.AddScoped<IGetByIdWalletUseCase, GetByIdWalletUseCase>();
        services.AddScoped<IUpdateWalletUseCase, UpdateWalletUseCase>();
    
        return services;
    }
}