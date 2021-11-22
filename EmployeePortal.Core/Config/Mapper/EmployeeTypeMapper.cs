using EmployeePortal.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortal.Core.Config.Mapper
{
    public static class EmployeeTypeMapper
    {
        public static IEnumerable<SelectListItem> Mapped(IEnumerable<EmployeeType> employeeTypes)
        {
            if (employeeTypes != null && employeeTypes.Count() > 0)
            {
                return employeeTypes.Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Desription,
                });
            }

            return null;
        }
    }
}
