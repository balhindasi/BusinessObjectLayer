using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public interface IJob
    {
        void Add(Job job);
        void Delete(Job job);
        void Save();
        Job GetDepById(Guid id);
        List<Job>GetAll();
        List<Department>GetAlldep();
    }
}
