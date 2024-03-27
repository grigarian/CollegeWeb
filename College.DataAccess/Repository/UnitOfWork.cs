using College.DataAccess.Data;
using College.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public ITeacherRepository Teacher { get; private set; }
        public ISpecializationRepository Specialization { get; private set; }
        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
            Teacher = new TeacherRepository(_db);
            Specialization = new SpecializationRepository(_db);
            
        }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
