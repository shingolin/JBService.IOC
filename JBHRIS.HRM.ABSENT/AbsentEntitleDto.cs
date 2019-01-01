using System;

namespace JBHRIS.HRM.ABSENT
{
    public class AbsentEntitleDto
    {
        public string EmployeeId { get; set; }
        public string HolidayCode { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Entitle { get; set; }
        public decimal Taken { get; set; }
        public decimal Balance { get; set; }
        public string Remark { get; set; }
    }
}