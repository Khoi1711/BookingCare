﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookingCareEntities1 : DbContext
    {
        public BookingCareEntities1()
            : base("name=BookingCareEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminOfHospital> AdminOfHospitals { get; set; }
        public virtual DbSet<AdminSystem> AdminSystems { get; set; }
        public virtual DbSet<BookingPatient> BookingPatients { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Speciaty> Speciaties { get; set; }
        public virtual DbSet<StaffSystem> StaffSystems { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StaffOfHospital> StaffOfHospitals { get; set; }
    }
}
