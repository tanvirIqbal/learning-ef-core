﻿using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Publisher_Id);
            modelBuilder.Property(x => x.Name).IsRequired();
        }
    }
}
