using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.Infrastructure.Identity;
using HorseMoney.Application.Models;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.Account;
using HorseMoney.Domain.Interfaces;
using HorseMoney.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HorseMoney.Application.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _emailSender = emailSender;
    }

    public async Task<(Result Result, string UserId)> RegisterAsync(IRegisterModel model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);


        // if (result.Succeeded)
        // {
        //     var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //     
        //     var baseUrl = _configuration["BaseUrl"]; 
        //     var confirmationLink = $"{baseUrl}/api/account/confirmEmail?userId={user.Id}&token={emailConfirmationToken}";
        //     
        //     await _emailSender.SendEmailAsync(user.Email, "Confirme seu e-mail", $"Por favor, confirme seu e-mail clicando neste link: {confirmationLink}");
        // }

        return (result.ToApplicationResult(), user.Id);
    }
    public async Task<BasicResult> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return BasicResult.Failure(new Error(HttpStatusCode.Unauthorized,"Unauthorized, Please check your Email or Password  and try again."));
        }
        
        var token = GenerateJwtToken(user);

        return BasicResult.Success(token);
    }
    
    private string GenerateJwtToken(ApplicationUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
            new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            },
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}