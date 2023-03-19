using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JobDAL : IJob
    {
        private readonly EMT_DBContext _db;
        public JobDAL(EMT_DBContext db)
        {
            _db = db;
        }
        public void Add(Job job)
        {
            _db.Jobs.Add(job);
        }
        

        public void Delete(Job job)
        {
            _db.Jobs.Remove(job);
        }

        public List<Job> GetAll()
        {
            return _db.Jobs.ToList();
        }

        public List<Department> GetAlldep()
        {
            return _db.Departments.Include(x => x.DepName).ToList();
        }


        public Job GetDepById(Guid id)
        {
            return _db.Jobs.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
