using Demo1.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizedAttribute : AuthorizeAttribute
    {
        public AuthorizedAttribute(params AuthRole[] roles)
        {
            if (roles.Length > 0) Roles = String.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
