using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployee
    {
        void Add(Employee employee );
        void Update(Employee employee); // param as entity consider as one row
        void Delete(Employee employee);
        void Save();
        Employee GetEmpbyId(string id);
        Job GetJobbyId(Guid id);
        List<Employee> GetAllEmp();
        List<Department> GetAllDep();
        //object GetEmpbyId(int id);
    }
}

