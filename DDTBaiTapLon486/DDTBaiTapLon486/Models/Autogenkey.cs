using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Autogenkey
    {
        public string GenerateKey(string id)
        {

            string strkey = "";
            string numPart = "", strPart = "", strPhanso = "";

            numPart = Regex.Match(id, @"\d+").Value;
            strPart = Regex.Match(id, @"\D+").Value;

            int Phanso = Convert.ToInt32(numPart) + 1;

            for (int i = 0; i < numPart.Length - Phanso.ToString().Length; i++)
            {
                strPhanso += "0";
            }
            strPhanso += Phanso;
            strkey = strPart + strPhanso;

            return strkey;
        }
    }
}