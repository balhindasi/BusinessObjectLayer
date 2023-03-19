using BusinessObjectLayer;
using BusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EvaluationDAL : IEvaluation
    {
        private readonly EMT_DBContext _db;
        public EvaluationDAL(EMT_DBContext db)
        {
            _db = db;
        }
        public void Add(Evaluation evaluation)
        {
            _db.Evaluations.Add(evaluation);
        }
        

        public void Delete(Evaluation evaluation)
        {
            _db.Evaluations.Remove(evaluation);
        }
        
        public List<Evaluation> GetAllEva()
        {
            return _db.Evaluations.ToList();
        }

        public Evaluation GetByEva(string id)
        {
            return _db.Evaluations.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Evaluation evaluation)
        {
            _db.Evaluations.Update(evaluation);
        }
    }
}
