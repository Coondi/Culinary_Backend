﻿using Culinary.Data.BindingModels;
using Culinary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }
            var result = await _accountService.Login(model);

            if(result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("LogOut")]
        public async Task LogOut()
        {
            await _accountService.LogOut();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            var userId = User.Identity.Name;
            var result = await _accountService.ChangePassword(userId, model);

            if(result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
  

    }
}
