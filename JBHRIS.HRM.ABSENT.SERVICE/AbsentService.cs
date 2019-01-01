using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBHRIS.HRM.ABSENT.SERVICE
{
    public class AbsentService : IAbsentService
    {
        private IAbsentServiceRepository _absentServiceRepository;
        private IAbsentServiceBll _absentServiceBll;

        public AbsentService(IAbsentServiceRepository absentServiceRepository,IAbsentServiceBll absentServiceBll)
        {
            _absentServiceRepository = absentServiceRepository;
            _absentServiceBll = absentServiceBll;
        }
        public bool CheckConflict(List<AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            return _absentServiceBll.CheckConflict(absentTakens, out ErrorMessage);
        }

        public List<AbsentTakenDto> CreateTakens(AbsentApplyDto absentApply)
        {
            return _absentServiceBll.CreateTakens(absentApply);
        }

        public bool DeleteAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            ErrorMessage = "";
            return _absentServiceRepository.DeleteAbsentTakens(absentTakens, out ErrorMessage);
        }

        public List<AbsentEntitleDto> GetEntitles(string EmployeeId, string HolidayCode, DateTime DateBegin, DateTime DateEnd)
        {
            return _absentServiceRepository.GetEntitles(EmployeeId, HolidayCode, DateBegin, DateEnd);
        }

        public List<AbsentTakenDto> GetTakens(string EmployeeId, DateTime DateBegin, DateTime DateEnd)
        {
            return _absentServiceRepository.GetTakens(EmployeeId, DateBegin, DateEnd);
        }

        public bool InsertAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            ErrorMessage = "";
            return _absentServiceRepository.InsertAbsentTakens(absentTakens, out ErrorMessage);
        }

        public bool UpdateAbsentTakens(List<AbsentTakenDto> absentTakens, out string ErrorMessage)
        {
            ErrorMessage = "";
            return _absentServiceRepository.UpdateAbsentTakens(absentTakens, out ErrorMessage);
        }
    }
}
