﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Data.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelmanagementEntities : DbContext
    {
        public HotelmanagementEntities()
            : base("name=HotelmanagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<hotel> hotels { get; set; }
        public virtual DbSet<room> rooms { get; set; }
    }
}
