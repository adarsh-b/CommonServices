using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServices.Business.Entities.FeeSchedule
{
    public class FeeScheduleData
    {
        public string CPTCode { get; set; }
        public string BillingSpecialty { get; set; }
        public string DoctorSpecialty { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public Decimal BasicUnit { get; set; }
        public Decimal Conversionfator { get; set; }
        public DateTime EffectiveFromDate { get; set; }
        public Nullable<DateTime> EffectiveToDate { get; set; }
    }
}
