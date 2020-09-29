using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    [MetadataType(typeof(CotizacionTransMetaData))]
    public partial class CotizacionTrans
    {
        public SelectList ModalidadPolizaList { get; set; }
        public SelectList CommodityList { get; set; }
        public SelectList TipoBienList { get; set; }
        public SelectList ModalidadCobList { get; set; }
        public SelectList TipoMercaList { get; set; }
        public SelectList TrayectoAsegList { get; set; }
        public SelectList MediosList { get; set; }
        public SelectList AjusteAltaSinList { get; set; }        
    }

    public partial class CotizacionTransMetaData
    {
        [Required(ErrorMessage = "La cotización es requerida")]
        public int CotizacionID { get; set; }

        [Required(ErrorMessage = "El Estimado Anual es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingresar un valor válido")]
        public Nullable<double> EstimadoAnual { get; set; }

        [Required(ErrorMessage = "El Deducible para Robo es requerido")]
        Nullable<decimal> DeducRobo { get; set; }
    }
}
