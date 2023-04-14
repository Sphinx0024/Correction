using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.Pointis.AndroidUI.Model
{
    public class PointageModel
    {
        public long PointageID { get; set; }
        public System.DateTime Jour { get; set; }
        public System.TimeSpan HeureEntree { get; set; }
        public System.TimeSpan HeureSortie { get; set; }
        public Nullable<long> EmployesID { get; set; }
    }
}
