using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DBContext context;
        public DepartmentService(DBContext context)
        {
            this.context = context;
        }
        public Department AddDepartment(Department department)
        {
           if(department == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return department;
            }
        }

        public void DeleteDepartment(Guid Id)
        {
            var department = context.Departments.FirstOrDefault(e => e.DepartmentId == Id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();

            }

        }

        public Department GetDepartment(Guid Id)
        {
            var department = context.Departments.Include(e=>e.BusinessCases).FirstOrDefault(s => s.DepartmentId == Id);
            if (department == null)
            {
                throw new NotImplementedException();

            }
            else
            {
           
                return department;
            }

        }

        public List<Department> GetDepartments()
        {
            return context.Departments.Include(e=>e.BusinessCases).ToList();
        }

        public Department UpdateDepartment(Guid Id, Department department)
        {

            if (Id != department.DepartmentId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(department).State = EntityState.Modified;
                context.SaveChanges();
                return department;
            }
        }
    }
}
