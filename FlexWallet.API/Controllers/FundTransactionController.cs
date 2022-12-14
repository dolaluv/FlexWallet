using FlexWallet.Abstractions.Models.Dtos;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.API.Helpers;
using FlexWallet.Data.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlexWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FundTransactionController : Controller
    {
        private readonly IWalletTransactionService walletTransactionService;

        public FundTransactionController(IWalletTransactionService walletTransactionService)
        {
            this.walletTransactionService = walletTransactionService ?? throw new ArgumentNullException(nameof(walletTransactionService));
        }

        [HttpPost("FundTransfer")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> FundTransfer([FromBody] WalletFundTransferDto walletFundTransferDto)
        {
            try
            {
                try
                {
                    var result = await this.walletTransactionService.FundTransfer(walletFundTransferDto);
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


        [HttpGet("GetWallectAccountBalanceByAccountNumber")] 
        public async Task<IActionResult> WallectAccountBalance( string wlletAccountNumber)
        {
            try
            {
                try
                {
                    var result = await this.walletTransactionService.GetAccountBalance(wlletAccountNumber);
                    if (result != null)
                        return Ok( result);
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
