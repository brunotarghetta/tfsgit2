using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.DataAccess.Base
{
    public class BcrContext : DbContext
    {
        public BcrContext()
        {

        }
        public BcrContext(DbContextOptions<BcrContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ServicioExternoEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new LogServicioEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new LogServicioExternoEntityConfiguration());
            //modelBuilder.Query<ProformaDataView>();
        }
    }
}
