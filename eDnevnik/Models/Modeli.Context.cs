﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDnevnik.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eDnevnik_v4Entities : DbContext
    {
        public eDnevnik_v4Entities()
            : base("name=eDnevnik_v4Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Dodeljene_ocene> Dodeljene_ocene { get; set; }
        public virtual DbSet<Dodeljeni_profesori> Dodeljeni_profesori { get; set; }
        public virtual DbSet<Ocene> Ocenes { get; set; }
        public virtual DbSet<Odeljenja> Odeljenjas { get; set; }
        public virtual DbSet<Predmeti> Predmetis { get; set; }
        public virtual DbSet<Predmetni_profesori> Predmetni_profesori { get; set; }
        public virtual DbSet<Profesori> Profesoris { get; set; }
        public virtual DbSet<Tipovi_ocena> Tipovi_ocena { get; set; }
        public virtual DbSet<Ucenici> Ucenicis { get; set; }
    }
}
