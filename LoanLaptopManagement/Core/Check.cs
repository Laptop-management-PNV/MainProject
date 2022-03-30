using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanLaptopManagement.Core
{
    public class Check
    {
        public static bool isLogedIn()
        {
            return SessionHelper.getSession() != null;
        }
    }
}