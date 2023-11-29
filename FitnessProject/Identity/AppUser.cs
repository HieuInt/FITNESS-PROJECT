using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;

namespace FitnessProject.Identity
{
    public class AppUser: IdentityUser
    {

        public DateTime? Birthday { get; set; }
    }
}