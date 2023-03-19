using BusinessLogicLayer;
using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAL : IEmployee
    {

        private readonly EMT_DBContext _db;
        public EmployeeDAL(EMT_DBContext db)
        {
            _db = db;
        }

        public void Add(Employee employee)
        {
            _db.Employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            _db.Employees.Remove(employee);
        }

        public List<Department> GetAllDep()
        {
            return _db.Departments.ToList();
        }

        public List<Employee> GetAllEmp()
        {
            return _db.Employees.ToList();
        }

        public Employee GetEmpbyId(string id)
        {
            return _db.Employees.Find(id);
        }

        public Job GetJobbyId(Guid id)
        {
            return _db.Jobs.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _db.Employees.Update(employee);
        }
    }
}
