using Microsoft.EntityFrameworkCore;
using RS1_vjezbe.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.EF
{
    public class MojDbContext : DbContext
    {
        public DbSet<Opcina> Opcina { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Server=localhost;
                                        Database=IB180070;
                                        Trusted_Connection=true;
                                        MultipleActiveResultSets=true;
                                        ");
        }
    }
}

