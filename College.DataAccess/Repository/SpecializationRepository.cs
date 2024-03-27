using College.DataAccess.Data;
using College.DataAccess.Repository.IRepository;
using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository
{
    public class SpecializationRepository: Repository<Specialization>, ISpecializationRepository
    {
        private readonly ApplicationDbContext _db;

        public SpecializationRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Specialization obj) { _db.Specializations.Update(obj); }
    }
}
