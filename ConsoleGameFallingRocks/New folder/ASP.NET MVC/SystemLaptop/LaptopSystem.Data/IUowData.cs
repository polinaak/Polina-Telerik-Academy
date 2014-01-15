﻿using LaptopSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Laptop> Laptops { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Role> Roles { get; }

        int SaveChanges();
    }
}
