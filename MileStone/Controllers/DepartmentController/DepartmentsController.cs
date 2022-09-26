using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.DepartmentServices;

namespace MileStone.Controllers.DepartmentController
{
  /*  [Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
 
        private readonly IDepartmentService departmentServices;

        public DepartmentsController(IDepartmentService departmentServices)
        {
          this.departmentServices = departmentServices;
        }

        // GET: api/Depatments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepatments()
        {
            return departmentServices.GetDepartments();
        }

        // GET: api/Depatments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepatment(Guid id)
        {
            try
            {
                return departmentServices.GetDepartment(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Depatments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Department PutDepatment(Guid id, Department depatment)
        {
            try
            {
                return departmentServices.UpdateDepartment(id,depatment);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: api/Depatments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Department> PostDepatment(Department depatment)
        {
            try
            {
                return departmentServices.AddDepartment(depatment);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Depatments/5
        [HttpDelete("{id}")]
        public void DeleteDepatment(Guid id)
        {
            try
            {
                departmentServices.DeleteDepartment(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
