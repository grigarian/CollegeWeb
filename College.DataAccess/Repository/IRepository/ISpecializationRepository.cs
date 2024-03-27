using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Repository.IRepository
{
    public interface ISpecializationRepository: IRepository<Specialization>
    {
        void Update(Specialization obj);
    }
}
