using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;



namespace project_ED_training.Repositories
{
    public class TechnicoDbContext: DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        
        public DbSet<Property> Properties { get; set; }
        public DbSet<Repair> Repairs { get; set; }

    }
}
