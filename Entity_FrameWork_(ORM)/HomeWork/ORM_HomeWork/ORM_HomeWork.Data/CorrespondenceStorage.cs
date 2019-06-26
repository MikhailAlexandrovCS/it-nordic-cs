using Microsoft.EntityFrameworkCore;
using ORM_HomeWork.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_HomeWork.Data
{
    public class CorrespondenceStorage : DbContext
    {
        private string _connectionString;

        public DbSet<PostalItem> PostalItem { get; set; }

        public DbSet<Contractor> Contractor { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Address> Adress { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<SendingStatus> SendingStatus { get; set; }

        public CorrespondenceStorage()
        {
            _connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Correspondence;Integrated Security=true";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SendingStatus>()
                .HasKey("PostalItemId", "UpdateStatusDateTime", "StatusId", "SendingContractorId", "SendingAdressId", "ReceivingContractorId", "ReceivingAdressId")
                .HasName("PK_SendingStatus")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<City>()
                .HasAlternateKey(n => n.Name)
                .HasName("UQ_City_Name");

            modelBuilder
                .Entity<PostalItem>()
                .HasKey(p => p.Id)
                .HasName("PK_PostalItem")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<Contractor>()
                .HasKey(p => p.Id)
                .HasName("PK_Сontractor")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<Position>()
                .HasKey(p => p.Id)
                .HasName("PK_Position")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<City>()
                .HasKey(p => p.Id)
                .HasName("PK_City")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<Address>()
                .HasKey(p => p.Id)
                .HasName("PK_Address")
                .ForSqlServerIsClustered();

            modelBuilder
                .Entity<Status>()
                .HasKey(p => p.Id)
                .HasName("PK_Status")
                .ForSqlServerIsClustered();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
