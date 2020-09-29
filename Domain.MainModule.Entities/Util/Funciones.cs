using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Util
{
    public static class Funciones
    {
        public static int getAño(string dato)
        {
            int year = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0,2) + dato);
            if (year > DateTime.Now.Year)
                return Convert.ToInt32((DateTime.Now.Year - 100).ToString().Substring(0,2) + dato);
            else
                return year;
        }
    }
}
