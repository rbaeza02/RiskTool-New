using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    [MetadataType(typeof(RCRecallMetaData))]
    public partial class CotizacionRCRecall
    {
        public SelectList CategoryList { get; set; }
        public SelectList CoverageList { get; set; }
        public SelectList ExposureTypeList { get; set; }
        public SelectList BatchAmountList { get; set; }
        public SelectList LimitList { get; set; }
        public SelectList DeducibleList { get; set; }
        public SelectList OccupancyList { get; set; }

        public string AdjustedRateRange
        {
            get { return AdjustedRateRangeMin.HasValue && AdjustedRateRangeMax.HasValue ? Math.Round(AdjustedRateRangeMin.Value, 2).ToString() + " - " + Math.Round(AdjustedRateRangeMax.Value, 2).ToString() : string.Empty; }
        }

        public string BasicRateRange
        {
            get { return BasicRateRangeMin.HasValue && BasicRateRangeMax.HasValue ? Math.Round(BasicRateRangeMin.Value, 2).ToString() + " - " + Math.Round(BasicRateRangeMax.Value, 2).ToString() : string.Empty; }
        }
    }

    public partial class RCRecallMetaData
    {
        [Required(ErrorMessage = "First/Third Party Factor: El valor es requerido")]
        [Range(0, 50, ErrorMessage = "First/Third Party Factor: Ingrese un valor válido entre 0% y 50%")]
        public Nullable<double> PartyFactor { get; set; }

        [Required(ErrorMessage = "Product Dispersion Factor: El valor es requerido")]        
        [Range(0.9, 1.1, ErrorMessage = "Product Dispersion Factor: Ingrese un valor válido entre 0.9 y 1.1")]
        public Nullable<double> Factor { get; set; }

        [Required(ErrorMessage = "ID and Tracking Systems: El valor es requerido")]
        [Range(0.9, 1.2, ErrorMessage = "ID and Tracking Systems: Ingrese un valor válido entre 0.9 y 1.2")]
        public Nullable<double> Systems { get; set; }

        [Required(ErrorMessage = "Labor and Technical Cost: El valor es requerido")]
        [Range(0.9, 1.3, ErrorMessage = "Labor and Technical Cost: Ingrese un valor válido entre 0.9 y 1.3")]
        public Nullable<double> Cost { get; set; }
    }
}
