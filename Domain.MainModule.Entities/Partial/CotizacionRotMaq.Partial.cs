﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionRotMaq
    {
        public SelectList GiroList { get; set; }
        public SelectList MantenimientoList { get; set; }        
    }
}
