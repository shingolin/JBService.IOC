
using System;
using System.Collections.Generic;

namespace JBHRIS.HRM.ABSENT.SERVICE
{
    public interface IAbsentServiceRepository
    {
        List<AbsentEntitleDto> GetEntitles(string EmployeeId, string HolidayCode, DateTime DateBegin, DateTime DateEnd);
        List<AbsentTakenDto> GetTakens(string EmployeeId, DateTime DateBegin, DateTime DateEnd);
        HolidayCodeInfoDto GetHolidayCodeInfoByCode(string HolidayCode);
        List<AttendanceInfoDto> GetAttendanceInfos(string EmployeeId, DateTime DateBegin, DateTime DateEnd);
        /// <summary>
        /// 新增請假紀錄
        /// </summary>
        /// <param name="absentTakens">請假明細</param>
        /// <param name="ErrorMessage">錯誤訊息</param>
        /// <returns></returns>
        bool InsertAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage);
        /// <summary>
        /// 修改請假紀錄
        /// </summary>
        /// <param name="absentTakens">請假明細</param>
        /// <param name="ErrorMessage">錯誤訊息</param>
        /// <returns></returns>
        bool UpdateAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage);
        /// <summary>
        /// 刪除請假紀錄
        /// </summary>
        /// <param name="absentTakens">請假明細</param>
        /// <param name="ErrorMessage">錯誤訊息</param>
        /// <returns></returns>
        bool DeleteAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage);
    }
}