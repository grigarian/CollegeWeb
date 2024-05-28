using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        ISpecializationRepository Specialization { get; }
        IGroupRepository Group { get; }

        void Save();
    }
}
