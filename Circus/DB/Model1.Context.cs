﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Circus.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CircussEntities1 : DbContext
    {
        public CircussEntities1()
            : base("name=CircussEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AnimalTrainer> AnimalTrainer { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Cell> Cell { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Perfomance> Perfomance { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SheduleArtist> SheduleArtist { get; set; }
        public virtual DbSet<SheduleTrainers> SheduleTrainers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
    }
}
