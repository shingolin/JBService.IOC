using System.Collections.Generic;

namespace JBHRIS.HRM.ABSENT.SERVICE
{
    public interface IAbsentServiceBll
    {
        List<AbsentTakenDto> CreateTakens(AbsentApplyDto absentApply);
        bool CheckConflict(List<AbsentTakenDto> absentTakens, out string errorMessage);
    }
}