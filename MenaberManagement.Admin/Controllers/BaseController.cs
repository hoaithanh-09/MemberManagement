using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("JWT");
            if (sessions == null)
                context.Result = new RedirectToActionResult("Index", "Login", null);
            base.OnActionExecuting(context);
        }

        protected string GetRoleNameFromToken()
        {
            return User?.FindFirst(ClaimTypes.Role)?.Value;
        }

        protected string GetUsernameFromToken()
        {
            return User?.FindFirst(ClaimTypes.Name)?.Value;
        }
        protected int GetUserIdFromToken()
        {
            try
            {
                return int.Parse(
                    User?.FindFirst(Constants.CLAIM_EMPLOYEE_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetUserIdFromToken " + e.Message);
                return -1;
            }
        }
        protected int GetAccountIdFromToken()
        {
            try
            {
                return int.Parse(
                    User?.FindFirst(Constants.CLAIM_ACCOUNT_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetAccountIdFromToken " + e.Message);
                return -1;
            }
        }
    }

    public class Constants
    {
        public const string CLAIM_EMPLOYEE_ID = "ID_CLAIM_TYPE";
        public const string CLAIM_ACCOUNT_ID = "ACCOUNT_ID";
        public const string CLAIM_UNIT_ID = "CLAIM_UNIT_ID";
    }
}
