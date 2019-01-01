using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBHRIS.HRM.ABSENT
{
    public interface IAbsentService
    {
        /// <summary>
        /// 取得得假資料
        /// </summary>
        /// <param name="EmployeeId">員工編號</param>
        /// <param name="HolidayCode">假別</param>
        /// <param name="DateBegin">起始日期</param>
        /// <param name="DateEnd">結束日期</param>
        /// <returns>得假資料</returns>
        List<AbsentEntitleDto> GetEntitles(string EmployeeId, string HolidayCode, DateTime DateBegin, DateTime DateEnd);
        /// <summary>
        /// 取得請假紀錄
        /// </summary>
        /// <param name="EmployeeId">員工編號</param>
        /// <param name="DateBegin">起始日期</param>
        /// <param name="DateEnd">結束日期</param>
        /// <returns>請假紀錄明細</returns>
        List<AbsentTakenDto> GetTakens(string EmployeeId, DateTime DateBegin, DateTime DateEnd);
        /// <summary>
        /// 產生請假紀錄明細
        /// </summary>
        /// <param name="absentApply">申請條件</param>
        /// <returns>請假紀錄明細</returns>
        List<AbsentTakenDto> CreateTakens(AbsentApplyDto absentApply);
        /// <summary>
        /// 檢查資料寫入是否有衝突
        /// </summary>
        /// <param name="absentTakens">請假明細</param>
        /// <param name="ErrorMessage">錯誤訊息</param>
        /// <returns></returns>
        bool CheckConflict(List<AbsentTakenDto> absentTakens,out string ErrorMessage);
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
