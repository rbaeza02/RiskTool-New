using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class IncCOPE
    {
        public SelectList RetroactiveList { get; set; }
        public SelectList TriggerList { get; set; }
        public SelectList TypeOcurrencyList { get; set; }        
    }
}
