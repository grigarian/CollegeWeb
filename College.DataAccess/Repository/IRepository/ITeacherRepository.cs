using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository.IRepository
{
    public interface ITeacherRepository: IRepository<Teacher>
    {
        void Update(Teacher teacher);
    }
}
