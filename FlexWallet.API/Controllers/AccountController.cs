using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models.Dtos;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlexWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(ResponseModel), 200)] 
        public async Task<IActionResult> SignUp([FromBody] WalletUserRegister walletUserDtos)
        {
            try
            {
                try
                {
                    var result = await this.accountService.WalletRegistration(walletUserDtos);
                    if (result != null && result.Status)
                        return Ok(StandardResponse.Ok(" Added Successfully", result));
                    else if (!result.Status)
                        return Ok(StandardResponse.Ok("Failed", result));
                    else
                        return BadRequest(StandardResponse.BadRequest("An error occured"));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }

        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> Login([FromBody] WalletUserLogin walletUserLogin)
        {
           
            try
                {
                var result = await this.accountService.WalletLogin(walletUserLogin); 
                if (result.Item1.Status)
                {
                    var token = AuthJwt.GenerateABearerToken(_configuration, result.Item2);  
                    result.Item1.Message = token.token;
                    return Ok(StandardResponse.Ok("Success", result.Item1));

                }
                else
                {
                    return Ok(StandardResponse.BadRequest("Failed", result.Item1));
                }

 
                }
                catch (Exception ex)
                {
                    return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
                }

            }
          
        }
       
}
