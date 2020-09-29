using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class PresentacionTrans
    {
        public List<SelectPresentacionTransporte_Result> Textos { get; set; }
        public List<TransCondicion> Condiciones { get; set; }
        public string MensajeError { get; set; }
        
    }
}
