﻿// <auto-generated />
using FilmApi.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmApi.Migrations
{
    [DbContext(typeof(FilmDbContext))]
    [Migration("20230816131539_AddMockData3")]
    partial class AddMockData3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FilmApi.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Bruce Wayne",
                            FullName = "Batman",
                            Gender = "Male",
                            Picture = "https://vignette.wikia.nocookie.net/legobatman/images/a/ac/Batman2_Batman.png/revision/latest?cb=20190331215239"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Harvey Dent",
                            FullName = "Two-face",
                            Gender = "Male",
                            Picture = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimages2.fanpop.com%2Fimage%2Fphotos%2F14300000%2FTwo-Face-lego-batman-14369888-560-560.jpg&f=1&nofb=1&ipt=dcb2afdec6f6bb0cfbcf68d1b26f9128215e332e08f748bc5819e4e5c0dcb6e9&ipo=images"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Jack White",
                            FullName = "Joker",
                            Gender = "Male",
                            Picture = "http://www.vignette1.wikia.nocookie.net/lego/images/8/8b/Non-Blurry_Joker.png/revision/latest?cb=20140722220222"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Darth Vader",
                            FullName = "Anakin Skywalker",
                            Gender = "Male",
                            Picture = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpm1.narvii.com%2F6511%2F484805d71056e4a2444767a89136a322c5ec09cb_hq.jpg&f=1&nofb=1&ipt=18a282eda5be08037a416b9216625664f16d872b79b757ae364936c65b1d297b&ipo=images"
                        });
                });

            modelBuilder.Entity("FilmApi.Models.CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("FilmApi.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Guys rich parents dies and he dresses up as a bat",
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 2,
                            Description = "They blow up stuff in space",
                            Name = "Star Wars"
                        });
                });

            modelBuilder.Entity("FilmApi.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Christopher Nolan",
                            FranchiseId = 1,
                            Genre = "Action,Crime,Drama",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/a/af/Batman_Begins_Poster.jpg",
                            ReleaseYear = 2005,
                            Title = "Batman Begins",
                            Trailer = "https://www.youtube.com/watch?v=8TtdY3_Am7w"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Christopher Nolan",
                            FranchiseId = 1,
                            Genre = "Action,Crime,Drama",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg",
                            ReleaseYear = 2008,
                            Title = "The Dark Knight",
                            Trailer = "https://www.youtube.com/watch?v=StWZDqqBfJo"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Christopher Nolan",
                            FranchiseId = 1,
                            Genre = "Action,Crime,Drama",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/8/83/Dark_knight_rises_poster.jpg",
                            ReleaseYear = 2012,
                            Title = "The Dark Knight Rises",
                            Trailer = "https://www.youtube.com/watch?v=dEwUwslyaEQ"
                        },
                        new
                        {
                            Id = 4,
                            Director = "George Lucas",
                            FranchiseId = 2,
                            Genre = "Sci-fi,Adventure",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg",
                            ReleaseYear = 1977,
                            Title = "A New Hope",
                            Trailer = "https://www.youtube.com/watch?v=bx9GYhpx10Q"
                        });
                });

            modelBuilder.Entity("FilmApi.Models.CharacterMovie", b =>
                {
                    b.HasOne("FilmApi.Models.Character", "Character")
                        .WithMany("CharacterMovie")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmApi.Models.Movie", "Movie")
                        .WithMany("CharacterMovie")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FilmApi.Models.Movie", b =>
                {
                    b.HasOne("FilmApi.Models.Franchise", null)
                        .WithMany("movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmApi.Models.Character", b =>
                {
                    b.Navigation("CharacterMovie");
                });

            modelBuilder.Entity("FilmApi.Models.Franchise", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("FilmApi.Models.Movie", b =>
                {
                    b.Navigation("CharacterMovie");
                });
#pragma warning restore 612, 618
        }
    }
}
