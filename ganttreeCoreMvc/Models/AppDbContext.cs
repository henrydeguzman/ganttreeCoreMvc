using ganttreeCoreMvc.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This appcontext indicates which entities it is going to manage
namespace ganttreeCoreMvc.Models
{
    // extend the Identity user to StoreUser
    public class AppDbContext: IdentityDbContext<StoreUser>
    {
        // constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
