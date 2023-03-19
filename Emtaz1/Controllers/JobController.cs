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
    public class JobController : Controller
    {
        private IDepartment _idepartment;
        private IJob _ijob;
        private readonly RoleManager<IdentityRole> _roleManager;

        public JobController(IDepartment department, IJob job, RoleManager<IdentityRole> roleManager)
        {
          
            _idepartment = department;
            _ijob = job;
            _roleManager = roleManager;
          
        }
        // GET: JobController
        public ActionResult Index()
        {
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(Job job)
        {
            job.JobId = Guid.NewGuid();
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");
            _ijob.Add(job);
            _ijob.Save();

            return View();
        }

        public ActionResult Details()
        {

            ViewBag.DepName = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");
            return View(_ijob.GetAll());
            
        }

    }
}
