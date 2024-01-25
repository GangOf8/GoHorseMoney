using System.Net;
using HorseMoney.Application.Models;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.Account;
using HorseMoney.Domain.Interfaces;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    { 
       
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (result, userId) = await _accountService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return Ok(new { UserId = userId });
            }

            return BadRequest(result.Errors);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<BasicResult>> Login(LoginDto loginDto)
        {
            var result =  await _accountService.LoginAsync(loginDto);
            
            return ResponseBase<BasicResult>(HttpStatusCode.Accepted, result);
     
        }
        
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword()
        {
           
            return Ok();
        }
        
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword()
        {
          
            return Ok();
        }
        
        
    }
}
