using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace notebook.microservice.data.models
{
    public class NoteBookDbContext : DbContext
    {
        public static string _connectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            IConfigurationRoot configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("NoteBookConnectionString");
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<NoteType> NoteType { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
