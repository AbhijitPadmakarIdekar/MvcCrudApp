﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudApp.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        int SaveChanges();
    }
}