﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_CORS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AngulaJS_ExampleEntities : DbContext
    {
        public AngulaJS_ExampleEntities()
            : base("name=AngulaJS_ExampleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MOBILE> MOBILE { get; set; }
        public DbSet<PRODUCT> PRODUCT { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}