using Application.Integration.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Integration
{
    public class WsAsegurado 
    {
        private wsSistran.DataClient dt;

        public WsAsegurado()
        {
            dt = new wsSistran.DataClient();
        }

        public string GrabarAsegurado(Domain.MainModule.Entities.Asegurado entAsegurado)
        {
            List<wsSistran.Asegurado> lista = new List<wsSistran.Asegurado>();
            lista.Add(TRASegurado.AseguradoTOwsAsegurado(entAsegurado));
            return dt.GuardarAsegurados(lista);
        }

        public Domain.MainModule.Entities.Asegurado ConsultarAsegurado(string rfc)
        {
            return TRASegurado.wsAseguradoTOAsegurado(dt.ConsultaAsegurados(rfc));            
        }

        public Domain.MainModule.Entities.Persona ConsultarPersona(string rfc)
        {
            return TRPersona.wsAseguradoTOPersona(dt.ConsultaAsegurados(rfc));            
        }

        public List<Domain.MainModule.Entities.CotizacionPagador> ConsultarPagadores(string rfc)
        {
            return TRConducto.wsConductoTOCotizacionPagador(dt.ConsultaConductos(rfc, null));
        }
    }
}
