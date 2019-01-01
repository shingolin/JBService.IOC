using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBHRIS.HRM.ABSENT.SERVICE;
using JBService.IOC;
using Dapper;

namespace JBHRIS.HRM.ABSENT.DAL
{
    public class AbsentServiceRepository : JBHRIS.HRM.ABSENT.SERVICE.IAbsentServiceRepository
    {
        private SqlConnection _connection;

        public AbsentServiceRepository(ConnectionHelper connectionHelper)
        {
            _connection = connectionHelper.GetConnection();
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Open();
        }
        public bool DeleteAbsentTakens(List<ABSENT.AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            throw new NotImplementedException();
        }

        public List<AttendanceInfoDto> GetAttendanceInfos(string EmployeeId, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }

        public List<ABSENT.AbsentEntitleDto> GetEntitles(string EmployeeId, string HolidayCode, DateTime DateBegin, DateTime DateEnd)
        {
            var results = _connection.Query<ABSENT.AbsentEntitleDto>(@"
                            select a.nobr EmployeeId,b.H_CODE_DISP,a.BDATE DateBegin,a.EDATE DateEnd,a.TOL_HOURS Entitle,a.LeaveHours Taken,a.Balance Balance,a.NOTE Remark from ABS a
                            join HCODE b on a.H_CODE=b.H_CODE
                            join HCODE c on b.HTYPE=c.HTYPE
                            where c.H_CODE_DISP=@HolidayCode
                            and a.nobr=@EmployeeId
                            and a.BDATE<=@DateEnd and a.EDATE>=@DateBegin
                            and b.flag='+'
                            ");
            return results.ToList();
        }

        public HolidayCodeInfoDto GetHolidayCodeInfoByCode(string HolidayCode)
        {
            throw new NotImplementedException();
        }

        public List<ABSENT.AbsentTakenDto> GetTakens(string EmployeeId, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }

        public bool InsertAbsentTakens(List<ABSENT.AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAbsentTakens(List<ABSENT.AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            throw new NotImplementedException();
        }
    }
}

