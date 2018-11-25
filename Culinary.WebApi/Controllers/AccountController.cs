using Culinary.Data.BindingModels;
using Culinary.Data.DbModels;
using Culinary.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Culinary.WebApi.Controllers
{
    [Route("Account")]
    public class AccountController : BaseResponseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            var result = await _accountService.Register(model);

            if(result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
  

    }
}
