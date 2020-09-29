using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Integration.Translate
{
    public static class TRASegurado
    {
        public static wsSistran.Asegurado AseguradoTOwsAsegurado(Domain.MainModule.Entities.Asegurado entAsegurado)
        {
            wsSistran.Asegurado wsAsegurado = new wsSistran.Asegurado();
            wsAsegurado.CodCiudad1 = entAsegurado.SISEcod_ciudad;
            wsAsegurado.CodColonia1 = entAsegurado.SISEcod_colonia;
            wsAsegurado.snNewComb = "0"; //Direccion existente
            wsAsegurado.CodDpto1 = entAsegurado.SISEcod_dpto;
            wsAsegurado.CodigoPostal = entAsegurado.CodigoPostal;
            wsAsegurado.CodEstCivil = entAsegurado.SISEcod_est_civil;
            wsAsegurado.CodMunicipio1 = entAsegurado.SISEcod_municipio;
            wsAsegurado.CodPais1 = entAsegurado.SISEcod_pais;
            wsAsegurado.CodTipoDir1 = "1"; //Dirección Fiscal
            wsAsegurado.CodTipoPersona = entAsegurado.SISEcod_TipoPersona;
            wsAsegurado.CodTipoTelef1 = entAsegurado.SISEcod_tipo_telef;
            wsAsegurado.Curp = entAsegurado.CURP;
            wsAsegurado.FecNac = entAsegurado.FechaNacimiento.ToString("yyyyMMdd");
            wsAsegurado.NroExterior1 = entAsegurado.DomicilioFiscal_NroExterior;
            wsAsegurado.NroInterior1 = entAsegurado.DomicilioFiscal_NroInterior;
            wsAsegurado.RFC = entAsegurado.RFC;
            wsAsegurado.TxtApellido1 = entAsegurado.TipoPersonaID == 1 ? entAsegurado.Apellido1 : entAsegurado.RazonSocial;
            wsAsegurado.TxtApellido2 = entAsegurado.TipoPersonaID == 1 ? entAsegurado.Apellido2 : string.Empty;
            wsAsegurado.TxtCalle1 = entAsegurado.DomicilioFiscal_Calle;
            wsAsegurado.TxtLugarNac = entAsegurado.LugarNacimiento;
            wsAsegurado.TxtNombre = entAsegurado.TipoPersonaID == 1 ? entAsegurado.Nombres : string.Empty;
            wsAsegurado.TxtSexo = entAsegurado.TipoPersonaID == 1 ? entAsegurado.bk_tc_Genero.SISEcod_sexo : string.Empty;
            wsAsegurado.TxtTelef1 = entAsegurado.Telefono;
            wsAsegurado.Agente = "0"; // false
            return wsAsegurado;
        }

        public static Domain.MainModule.Entities.Asegurado wsAseguradoTOAsegurado(wsSistran.Asegurado wsAsegurado)
        {            
            if (wsAsegurado.RFC == "") //Esto devuelve el WS cuando no lo encuentra
                return null;

            Domain.MainModule.Entities.Asegurado entAsegurado = new Domain.MainModule.Entities.Asegurado(wsAsegurado.RFC);
            
            //entAsegurado.Cod_ciudad = wsAsegurado.CodCiudad1; 
            entAsegurado.Cod_colonia = wsAsegurado.CodColonia1; 
            //entAsegurado.Cod_dpto = wsAsegurado.CodDpto1;
            entAsegurado.CodigoPostal = wsAsegurado.CodigoPostal;
            entAsegurado.Cod_est_civil = wsAsegurado.CodEstCivil; 
            //entAsegurado.Cod_municipio = wsAsegurado.CodMunicipio1; 
            //entAsegurado.Cod_pais = wsAsegurado.CodPais1; 
            entAsegurado.Cod_TipoPersona = wsAsegurado.CodTipoPersona; 
            entAsegurado.Cod_tipo_telef = wsAsegurado.CodTipoTelef1; 
            entAsegurado.CURP = wsAsegurado.Curp;
            entAsegurado.FechaNacimiento = DateTime.ParseExact(wsAsegurado.FecNac, "yyyyMMdd", CultureInfo.InvariantCulture);
            entAsegurado.DomicilioFiscal_NroExterior = wsAsegurado.NroExterior1;
            entAsegurado.DomicilioFiscal_NroInterior = wsAsegurado.NroInterior1;

            if (wsAsegurado.CodTipoPersona == "0") //Persona Física
            {
                entAsegurado.Apellido1 = wsAsegurado.TxtApellido1;
                entAsegurado.Apellido2 = wsAsegurado.TxtApellido2;
            }
            else
                entAsegurado.RazonSocial = wsAsegurado.TxtApellido1;

            entAsegurado.DomicilioFiscal_Calle = wsAsegurado.TxtCalle1;
            entAsegurado.LugarNacimiento = wsAsegurado.TxtLugarNac;
            entAsegurado.Nombres = wsAsegurado.TxtNombre;
            entAsegurado.Cod_sexo = wsAsegurado.TxtSexo; 
            entAsegurado.Telefono = wsAsegurado.TxtTelef1;
            return entAsegurado;
        }
    }
}