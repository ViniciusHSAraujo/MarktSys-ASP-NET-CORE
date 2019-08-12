using System;
using System.Collections.Generic;
using System.Text;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarktSys_ASP_NET_CORE.Data
{
    public class ApplicationDbContext : IdentityDbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){

        }
    }
}
