using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    public class MusicStreamingDataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFilePath = GetPath();
            optionsBuilder.UseSqlite($"Data Source={solutionFilePath}/Data/MusicStreamingDB.db");
        }

        private string GetPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionFilePath = null;

            while (currentDirectory != null)
            {
                string[] solutionFiles = Directory.GetFiles(currentDirectory, "*.sln");
                if (solutionFiles.Length > 0)
                {
                    solutionFilePath = currentDirectory;
                    break;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }
            return solutionFilePath;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.Album_Id);

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.Id_user, f.Id_song });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.Id_user);

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Favorites)
                .WithOne(f => f.Song)
                .HasForeignKey(f => f.Id_song);

        }

    }
}
