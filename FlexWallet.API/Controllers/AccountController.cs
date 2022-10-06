using FlexWallet.Abstractions.Models.Dtos;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
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
                try
                {
                    var result = await this.accountService.WalletLogin(walletUserLogin);
                    if (result != null && result.Status)
                        return Ok(StandardResponse.Ok("Success", result));
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

    }
}
