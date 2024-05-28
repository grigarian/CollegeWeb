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
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public GroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Group obj) { _db.Groups.Update(obj); }
    }
}
