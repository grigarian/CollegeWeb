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
    public class TeacherRepository: Repository<Teacher>, ITeacherRepository
    {
        private ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher obj)
        {
            //var objFromDb = _db.Teachers.FirstOrDefault(u => u.Id == obj.Id);
            //if(objFromDb != null)
            //{
            //    objFromDb.Name = obj.Name;
            //    objFromDb.Post = obj.Post;
            //    objFromDb.Education = obj.Education;
            //    objFromDb.Qualification = obj.Qualification;
            //    objFromDb.WorkExperience = obj.WorkExperience;
            //    if(obj.ImageUrl != null)
            //    {
            //        objFromDb.ImageUrl = obj.ImageUrl;
            //    }
            //}
            _db.Teachers.Update(obj);
        }
    }
}
