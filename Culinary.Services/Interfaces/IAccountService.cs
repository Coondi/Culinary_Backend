using Culinary.Data.BindingModels;
using Culinary.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Culinary.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseDTO<BaseModelDTO>> Register (RegisterBindingModel model);
        Task<ResponseDTO<LoginDTO>> Login(LoginBindingModel model);
        Task LogOut();
        Task<ResponseDTO<BaseModelDTO>> ChangePassword(string userId, ChangePasswordBindingModel model);
        Task<ResponseDTO<BaseModelDTO>> GetUserByCookie(string userId);
    }
}
