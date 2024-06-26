﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using library.Infrastructure;

#nullable disable

namespace library.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("library.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Password")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@gmail.com",
                            FullName = "Dostoevsky"
                        });
                });

            modelBuilder.Entity("library.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Thus Spoke Zarathustra"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Crime and Punishment"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Notes from Underground"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Last day of a Condemned Man"
                        });
                });

            modelBuilder.Entity("library.Domain.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            BookId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            BookId = 3
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            BookId = 4
                        });
                });

            modelBuilder.Entity("library.Domain.BookGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 3,
                            GenreId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            GenreId = 2
                        },
                        new
                        {
                            Id = 5,
                            BookId = 4,
                            GenreId = 3
                        },
                        new
                        {
                            Id = 6,
                            BookId = 2,
                            GenreId = 3
                        },
                        new
                        {
                            Id = 7,
                            BookId = 2,
                            GenreId = 2
                        });
                });

            modelBuilder.Entity("library.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Philosophy"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Crime"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Drama"
                        });
                });

            modelBuilder.Entity("library.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("library.Domain.BookAuthor", b =>
                {
                    b.HasOne("library.Domain.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId");

                    b.HasOne("library.Domain.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("library.Domain.BookGenre", b =>
                {
                    b.HasOne("library.Domain.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("library.Domain.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("library.Domain.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("library.Domain.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("library.Domain.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
