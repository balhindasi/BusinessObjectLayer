using BusinessLogicLayer;
using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Emtyaz.Controllers
{
    public class EvaluationController : Controller
    {
        private IEmployee _iEmployee;
        private  IEvaluation _evaluation;
        private readonly UserManager<IdentityUser> _userManager;
        public EvaluationController(IEmployee employee, UserManager<IdentityUser> userManager, IEvaluation evaluation)
        {
            _iEmployee = employee;
            _evaluation = evaluation;
           
            this._userManager = userManager;
        }
        // GET: EvaluationController
        public ActionResult Index()
        {
            //ViewBag.EmployeeId = new SelectList(_userManager.Users, "Id", "FullName");
          
            ViewBag.EmployeeeId = new SelectList(_iEmployee.GetAllEmp(), "EmployeeID", "FullName");

            return View();
        }
        [HttpPost]
        public ActionResult Index(Evaluation evaluation)
        {
            try
            {
           
                

                ViewBag.EmployeeId = new SelectList(_iEmployee.GetAllEmp(), "EmployeeID", "FullName");

                _evaluation.Add(evaluation);
                _evaluation.Save();

                
                return RedirectToAction("Details", new { id = evaluation.EmployeeId });
            }
            catch
            {

                return View();
            }
        }
        // GET: EvaluationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EvaluationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // PO
        // ST: EvaluationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvaluationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EvaluationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvaluationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EvaluationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
