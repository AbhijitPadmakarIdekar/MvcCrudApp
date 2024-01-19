using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvcCrudApp.Data.Context;
using MvcCrudApp.Domain.Entities;
using MvcCrudApp.Domain.Repository;

namespace MvcCrudApp.Data.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
