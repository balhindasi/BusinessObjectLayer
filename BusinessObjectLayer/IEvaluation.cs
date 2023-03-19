using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public interface IEvaluation
    {
        void Add(Evaluation evaluation);
        void Update(Evaluation evaluation); 
        void Delete(Evaluation evaluation);
        void Save();
      
       Evaluation GetByEva(string id);
        List<Evaluation> GetAllEva();

    }
}
