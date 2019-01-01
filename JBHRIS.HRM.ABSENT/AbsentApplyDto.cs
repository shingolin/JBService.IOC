using System;

namespace JBHRIS.HRM.ABSENT
{
    public class AbsentApplyDto
    {
        public string EmployeeId { get; set; }
        public string HolidayCode { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal? TotalTaken { get; set; }
        public string Remark { get; set; }
    }
}