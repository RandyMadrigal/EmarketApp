using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmarketApp.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using EmarketApp.Core.Application.Helpers;

namespace WebApp.EmarketApp.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            UserVm userVm = _httpContextAccessor.HttpContext.Session.Get<UserVm>("user");

            if (userVm == null)
            {
                return false;
            }

            return true;
        }
    }
}
