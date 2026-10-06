using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DataModelContext : DbContext
    {
        public DbSet<Disciplina> Discipline { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Giudice> Giudici { get; set; }
        public DbSet<Partecipante> Partecipanti { get; set; }
        public DbSet<Gara> Gare { get; set; }
        public DbSet<Votazione> Votazioni { get; set; }
        public string DbPath { get; }

        public DataModelContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "SketingSystem.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseLazyLoadingProxies().UseSqlite($"Data Source={DbPath}");
    }
}
