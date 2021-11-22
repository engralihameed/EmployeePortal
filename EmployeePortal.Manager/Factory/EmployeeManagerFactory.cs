using EmployeePortal.Core.Data.Enums;
using EmployeePortal.Handler.Interfaces;
using EmployeePortal.Handler.Manager;

namespace EmployeePortal.Handler.Factory
{
    public class EmployeeManagerFactory
    {
        public IEmployeeManager GetEmployeeManager(EmployeeJobType employeeJobType)
        {
            IEmployeeManager returnValue = null;
            if (employeeJobType == EmployeeJobType.Permanent)
            {
                returnValue = new PermanentEmployeeManager();
            }
            else if (employeeJobType == EmployeeJobType.Contract)
            {
                returnValue = new ContractEmployeeManager();
            }
            return returnValue;
        }
    }
}
