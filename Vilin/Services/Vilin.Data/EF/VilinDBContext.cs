using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Data
{
    [Export("EF", typeof(DbContext))]
    public class VilinDBContext : DbContext
    {
        public VilinDBContext(): base("default") { }

        public VilinDBContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public VilinDBContext(DbConnection existingConnection) : base(existingConnection, true) { }

        [ImportMany(typeof(IEntityMapper))]
        public IEnumerable<IEntityMapper> EntityMappers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
