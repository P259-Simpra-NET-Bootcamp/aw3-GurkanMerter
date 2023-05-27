﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WS.Base.Models;

namespace WS.Data.Domain
{
    [Table("Category", Schema = "dbo")]
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual List<Product>  Products { get; set; }

    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Order).IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique(true);

            builder.HasMany(x=>x.Products).WithOne(x=>x.Category).HasForeignKey(x=>x.CategoryId).IsRequired(true);
        }
    }
}
