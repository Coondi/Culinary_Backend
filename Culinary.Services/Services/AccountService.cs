using Culinary.Data.BindingModels;
using Culinary.Data.ModelsDTO;
using Culinary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Culinary.Data.DbModels;
using AutoMapper;
using System.Linq;

namespace Culinary.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountService(IHttpContextAccessor httpContext, UserManager<User> userManager, IMapper mapper)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _mapper = mapper;
        }



        public Task<ResponseDTO<BaseModelDTO>> ChangePassword(string userId, ChangePasswordBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<BaseModelDTO>> GetUserByCookie(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<LoginDTO>> Login(LoginBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<BaseModelDTO>> Register(RegisterBindingModel model)
        {
            var response = new ResponseDTO<BaseModelDTO>();
            var userFindByName = await _userManager.FindByNameAsync(model.UserName);

            if(userFindByName != null)
            {
                response.Errors.Add("Użytkownik o takiej nazwie już istnieje");
            }

            var userFindByMail = await _userManager.FindByEmailAsync(model.Email);
            if(userFindByMail == null && userFindByMail == null)
            {
                var user = new User()
                {
                    Id = model.UserName,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        response.Errors.Add(error.Description);
                    }
                    return response;
                }
            }

            return response;
        }
    }
}
