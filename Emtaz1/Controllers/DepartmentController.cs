using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Emtyaz.Controllers
{

    [Authorize(Roles = "Manager")]
    public class DepartmentController : Controller
    {
        private IDepartment _idepartment;
        private readonly RoleManager<IdentityRole> _roleManager;


        public DepartmentController(IDepartment department, RoleManager<IdentityRole> roleManager )
        {

            _idepartment = department;
            _roleManager = roleManager;
          

        }
        // GET: JobController
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Department department)
        {
            department.DepartmentId = Guid.NewGuid();
         
            _idepartment.Add(department);
            _idepartment.Save();

            return View();
        }


    }
}
