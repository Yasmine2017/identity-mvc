using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identityyy.Models
{
    public class mainDBcontect:DbContext
    {
        public mainDBcontect():base("DefaultConnection")
        {

        }
        public DbSet<reg> regs { set; get; }
    }
}