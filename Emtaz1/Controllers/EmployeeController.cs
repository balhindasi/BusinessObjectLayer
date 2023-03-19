using BusinessLogicLayer;
using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Emtyaz.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeeController : Controller
    {
        private IEmployee _iEmployee;
        private IDepartment _idepartment;
        private IJob _ijob;
        private IEvaluation _ievaluation;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeController(IEmployee employee, UserManager<IdentityUser> userManager, IDepartment department, IJob job, IEvaluation ievaluation, RoleManager<IdentityRole> roleManager)
        {
            _iEmployee = employee;
            _idepartment = department;
            _ijob = job;
            this._userManager = userManager;
            _ievaluation = ievaluation;
            _roleManager = roleManager;
        }
        // GET: EmployeeController
        public ActionResult Index(string id)
        {
            ViewBag.EmployeeId = new SelectList(_iEmployee.GetAllEmp(), "Id", "Email");
            ViewBag.JobId = new SelectList(_ijob.GetAll(), "Jobname");
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepName");

            var employee = _iEmployee.GetEmpbyId(id);
            if (employee == null)
            {
                return RedirectToAction("Details");
            }

            if (id == null)
            {
                return RedirectToAction("index");
            }
           

            return View(employee);

            //try
            //{
            //        ViewBag.JobId = new SelectList(_ijob.GetAll(), "JobId", "Jobname");
            //    ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");

            //    return RedirectToAction("create");
            //}
            //catch
            //{
            //    return View(employee);
            //}
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(string id)
        {

            //ViewBag.EmployeeId = new SelectList(_userManager.Users, "Id", "Email");
            //ViewBag.JobId = new SelectList(_ijob.GetAll(), "Jobname");
            //ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepName");
            //ViewBag.id = new SelectList(_ievaluation.GetAllEva(), "id", "Socialv", "Collaboration", "LeaderShip");
            //if (id == null)
            //{
            //    return RedirectToAction("Index");
            //}
            //var employee = _iEmployee.GetEmpbyId(id);
            //if (employee == null)
            //{
            //    return RedirectToAction("create");
            //}
            //return RedirectToAction("Details", new { id = employee.EmployeeID });


            ViewBag.JobId = new SelectList(_ijob.GetAll(), "Jobname");
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepName");
            if (id == null)
            {
                return RedirectToAction("Details");
            }
            var employee = _iEmployee.GetEmpbyId(id);
            if (employee == null)
            {
                return RedirectToAction("create");
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_userManager.Users, "Id", "Email");
            ViewBag.JobId = new SelectList(_ijob.GetAll(), "JobId", "Jobname");
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, Department department, Job job)
        {
            try
            {
                ViewBag.EmployeeId = new SelectList(_userManager.Users, "Id", "Email");


                ViewBag.JobId = new SelectList(_ijob.GetAll(), "JobId", "Jobname");


                ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");

                _iEmployee.Add(employee);
                _iEmployee.Save();
                return RedirectToAction("Details", new { id = employee.EmployeeID });
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string id)
        {
            var emp = _iEmployee.GetEmpbyId(id);
            ViewBag.JobId = new SelectList(_ijob.GetAll(), "JobId", "Jobname");
            ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");

            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {

            try
            {
                ViewBag.JobId = new SelectList(_ijob.GetAll(), "JobId", "Jobname");
                ViewBag.DepartmentId = new SelectList(_idepartment.GetAllDep(), "DepartmentId", "DepName");

                _iEmployee.Update(employee);
                _iEmployee.Save();
                return RedirectToAction("index", new { id = employee.EmployeeID });
            }
            catch
            {
                return View(employee);
            }
        }
    
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_iEmployee.GetEmpbyId(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, int fake)
        {

            try
            {
                var emp = _iEmployee.GetEmpbyId(id);

                _iEmployee.Delete(emp);
                _iEmployee.Save();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
