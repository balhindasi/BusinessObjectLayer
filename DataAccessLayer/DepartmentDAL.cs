using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    
    public class DepartmentDAL : IDepartment
    {
        private readonly EMT_DBContext _db;
        public DepartmentDAL(EMT_DBContext db)
        { 
            _db = db;
        }
        public void Add(Department department)
        {
            _db.Departments.Add(department);
        }
        
        public void Delete(Department department)
        {
            _db.Departments.Remove(department);
        }

        public List<Department> GetAllDep()
        {
            return _db.Departments.ToList();
        }

        public Department GetDepById(Guid id)
        {
            return _db.Departments.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
