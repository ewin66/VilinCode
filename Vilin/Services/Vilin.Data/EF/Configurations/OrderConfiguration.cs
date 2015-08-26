using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Data
{
    public class OrderConfiguration : EntityTypeConfiguration<OrderModel>
    {
        public OrderConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.OrderCode).HasMaxLength(20);
            Property(d => d.ProductCode).HasMaxLength(20);
            Property(d => d.State);
            Property(d => d.CreateDate);
        }
    }
}
