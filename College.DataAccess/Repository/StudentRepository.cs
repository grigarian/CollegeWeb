using College.DataAccess.Data;
using College.DataAccess.Repository.IRepository;
using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository
{
    public class StudentRepository: Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;
        
        public StudentRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }

        public void Update(Student obj)
        {
            _db.Students.Update(obj);
        }
    }
}
