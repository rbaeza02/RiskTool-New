using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Integration.Translate
{
    public static class TRPersona
    {        
        public static Domain.MainModule.Entities.Persona wsAseguradoTOPersona(wsSistran.Asegurado wsAsegurado)
        {
            if (wsAsegurado.RFC == "") //Esto devuelve el WS cuando no lo encuentra
                return null;

            Domain.MainModule.Entities.Persona entPersona = new Domain.MainModule.Entities.Persona();
            
            if (wsAsegurado.CodTipoPersona == "0") //Persona Física
            {
                entPersona.Apellido1 = wsAsegurado.TxtApellido1;
                entPersona.Apellido2 = wsAsegurado.TxtApellido2;
            }
            else
                entPersona.RazonSocial = wsAsegurado.TxtApellido1;

            entPersona.Nombres = wsAsegurado.TxtNombre;
            entPersona.SISEcod_Aseg = Convert.ToInt32(wsAsegurado.CodAseg);

            return entPersona;
        }
    }
}