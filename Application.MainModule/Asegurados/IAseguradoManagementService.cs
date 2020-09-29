using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.MainModule.Asegurados
{
    public interface IAseguradoManagementService
    {
        List<Asegurado> FindAseguradobyFiltro(string rfc, string razonSocial, string nombre, string apellido1, string apellido2);
        Asegurado FindwsAseguradobyRFC(string rfc, int usuarioID);
        Asegurado FindAseguradobyRFC(string rfc);
        Asegurado FindAseguradobyID(int aseguradoID);
        void SavewsAsegurado(Asegurado asegurado);
        List<string> GetDiferenciaAsegurado(int aseguradoID);
        List<Ubicacion> FindUbicaciones(int aseguradoID, string pagina, int tamaño);
        List<Ubicacion> FindUbicacionbyNroUbic(int aseguradoID, int nroUbicacion);

        void SaveUbicacion(List<Ubicacion> ubicaciones);

        int TotalUbicaciones(int aseguradoID);
        List<Table> FindCatalogoUbicaciones(int cotizacionID);

        int BuscarOFAC(Asegurado asegurado);

        Persona FindPersonabyRFC(string rfc);
        void SavePersona(XmlDocument datos, int cotizacionID, int ubicacionID);

        int GetNumberBenefbyCotizacion(int cotizacionID);
    }
}
