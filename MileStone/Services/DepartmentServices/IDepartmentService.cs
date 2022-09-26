using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public Department GetDepartment(Guid Id);
        public Department AddDepartment(Department department);
        public Department UpdateDepartment(Guid Id, Department department);
        public void DeleteDepartment(Guid Id);
    }
}
