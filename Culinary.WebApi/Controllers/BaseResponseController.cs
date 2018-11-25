using Culinary.Data.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culinary.WebApi.Controllers
{
    public class BaseResponseController : Controller
    {
        protected ResponseDTO<BaseModelDTO> ModelStateErrors()
        {
            var response = new ResponseDTO<BaseModelDTO>();

            foreach (var key in ModelState.Keys)
            {
                var value = ViewData.ModelState[key];

                foreach (var error in value.Errors)
                {
                    if(error.Exception != null)
                    {
                        response.Errors.Add("Nieprawidłowy format danych");
                    }
                    else
                    {
                        response.Errors.Add(error.ErrorMessage);
                    }
                }
            }

            return response;
        }
    }
}
