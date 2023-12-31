﻿using FilmApi.Data_Access;
using FilmApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data_Access
{
    public class FilmDbContext : DbContext
    {

        public FilmDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterMovie> CharacterMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterMovie>().HasKey(pq => new { pq.CharacterId, pq.MovieId });


            modelBuilder.Entity<Franchise>().HasData(SeedHelper.GetFranchises());
            modelBuilder.Entity<Movie>().HasData(SeedHelper.GetMovies());
            modelBuilder.Entity<Character>().HasData(SeedHelper.GetCharacters());

            modelBuilder.Entity<CharacterMovie>().HasData(SeedHelper.GetCharacterMovies());
        }

    }
}

