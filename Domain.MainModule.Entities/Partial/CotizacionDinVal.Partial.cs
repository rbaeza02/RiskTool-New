﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionDinVal
    {
        public SelectList CilindroList { get; set; }
        public SelectList GiroList { get; set; }
        public SelectList PoliciaList { get; set; }
        public SelectList TipoAlarmaList { get; set; }
    }
}
