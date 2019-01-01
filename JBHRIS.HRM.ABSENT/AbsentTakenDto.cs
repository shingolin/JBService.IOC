using System;

namespace JBHRIS.HRM.ABSENT
{
    public class AbsentTakenDto
    {
        public string EmployeeId { get; set; }
        public string HolidayCode { get; set; }
        public DateTime AbsentDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal? Taken { get; set; }
        public string Remark { get; set; }
    }
}
