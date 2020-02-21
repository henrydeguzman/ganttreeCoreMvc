using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganttreeCoreMvc.Data.Entities
{
    public class StoreUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string photoUrl { get; set; }
        public string last_job_no { get; set; }
    }
}
