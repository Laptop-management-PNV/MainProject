using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanLaptopManagement.Core
{
    public class SessionHelper
    {
        private static readonly string SESSIONKEY = "adminLogin";
        public static void setSession(AdminSession session)
        {
            HttpContext.Current.Session[SESSIONKEY] = session;
        }
        public static AdminSession getSession()
        {
            var session = HttpContext.Current.Session[SESSIONKEY];
            return session == null ? null : session as AdminSession;
        }

    }
}