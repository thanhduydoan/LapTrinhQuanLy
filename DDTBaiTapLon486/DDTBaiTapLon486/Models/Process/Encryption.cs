using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DDTBaiTapLon486.Models
{
    public class Encryption
    {
        public string PasswordEncryption(String pass) // ma hoa chuoi mat khau
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }
    }
}