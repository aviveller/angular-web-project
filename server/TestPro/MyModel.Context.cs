﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestPro
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class testdbEntities : DbContext
    {
        public testdbEntities()
            : base("name=testdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Location> Location { get; set; }
    }
}
