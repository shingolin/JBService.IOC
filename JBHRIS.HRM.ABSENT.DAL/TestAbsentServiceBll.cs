using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBHRIS.HRM.ABSENT.DAL
{
    public class TestAbsentServiceBll : JBHRIS.HRM.ABSENT.SERVICE.IAbsentServiceBll
    {
        public bool CheckConflict(List<AbsentTakenDto> absentTakens, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<AbsentTakenDto> CreateTakens(AbsentApplyDto absentApply)
        {
            throw new NotImplementedException();
        }
    }
}
