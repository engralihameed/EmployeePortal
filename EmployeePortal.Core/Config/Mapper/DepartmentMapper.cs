using EmployeePortal.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortal.Core.Config.Mapper
{
    public static class DepartmentMapper
    {
        public static IEnumerable<SelectListItem> Mapped(IEnumerable<Department> departments)
        {
            if (departments != null && departments.Count() > 0)
            {
                return departments.Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                });
            }

            return null;
        }
    }
}
