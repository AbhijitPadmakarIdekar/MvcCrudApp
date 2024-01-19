using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvcCrudApp.Domain.Entities;

namespace MvcCrudApp.Domain.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
