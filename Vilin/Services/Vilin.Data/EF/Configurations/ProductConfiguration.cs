using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Data
{
    public class ProductConfiguration : EntityTypeConfiguration<ProductModel>
    {
        public ProductConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.ProductCode).HasMaxLength(20);
            Property(d => d.ProductName).HasMaxLength(200);
            //HasMany(d => d.Orders).WithRequired(l => l.Product).Map(c => c.MapKey("ProductCode"));
            Property(d => d.Count);
            Property(d => d.State);
            Property(d => d.CreateDate);
        }
    }
}
