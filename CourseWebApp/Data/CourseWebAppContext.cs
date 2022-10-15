using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourseWebApp.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CourseWebApp.Data
{
    public class CourseWebAppContext : DbContext
    {
        public CourseWebAppContext (DbContextOptions<CourseWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CourseWebApp.Models.Department> Department { get; set; } = default!;

        public DbSet<CourseWebApp.Models.SalesRecord> SalesRecord { get; set; }

        public DbSet<CourseWebApp.Models.Seller> Seller { get; set; }
    }
}
