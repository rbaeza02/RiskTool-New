using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionRCProductoExt
    {
        public SelectList ActInmLimAgregadoList { get; set; }
        public SelectList ProdLimAgregadoList { get; set; }
        public SelectList TipoCoberturaList { get; set; }
        public SelectList BaseDeducibleList { get; set; }
    }
}
