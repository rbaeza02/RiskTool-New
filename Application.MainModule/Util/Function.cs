using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Util
{
    public class Function
    {
        public static bool IsOKSISE(string dato)
        {
            int valor;

            if (dato.IndexOf("_") > 0)
                return int.TryParse(dato.Substring(0, dato.IndexOf("_")), out valor);
            else
                return false;
        }

        public static Nullable<int> NroPolizaSISE(string dato)
        {
            int valor;

            if (int.TryParse(dato.Substring(6,8), out valor))                
                    return valor;            
            return null;
            
        }

        public static List<string> ReadFile(string path)
        {
            StreamReader objReader = new StreamReader(path);
            string sLine = "";
            List<string> arrText = new List<string>();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            return arrText;

        }
    
    }
}
