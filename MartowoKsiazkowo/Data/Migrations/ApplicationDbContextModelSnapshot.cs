﻿// <auto-generated />
using System;
using MartowoKsiazkowo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MartowoKsiazkowo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("MartowoKsiazkowo.Encje.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AutorImie")
                        .HasColumnType("TEXT");

                    b.Property<string>("AutorNazwisko")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookInfoId");

                    b.HasIndex("BookUserId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.BookInfo", b =>
                {
                    b.Property<int>("BookInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gatunek")
                        .HasColumnType("TEXT");

                    b.HasKey("BookInfoId");

                    b.ToTable("BookInfo", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.BookUser", b =>
                {
                    b.Property<int>("BookUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataOd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataWyp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookUserId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUser", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("BookId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.UserAddress", b =>
                {
                    b.Property<int>("UserAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Miasto")
                        .HasColumnType("TEXT");

                    b.Property<int>("NrDomu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NrTelefonu")
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("Ulica")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserAddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAddress", (string)null);
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.Book", b =>
                {
                    b.HasOne("MartowoKsiazkowo.Encje.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MartowoKsiazkowo.Encje.BookInfo", "BookInfo")
                        .WithMany("Books")
                        .HasForeignKey("BookInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MartowoKsiazkowo.Encje.BookUser", null)
                        .WithMany("Books")
                        .HasForeignKey("BookUserId");

                    b.Navigation("Author");

                    b.Navigation("BookInfo");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.BookUser", b =>
                {
                    b.HasOne("MartowoKsiazkowo.Encje.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MartowoKsiazkowo.Encje.User", "User")
                        .WithMany("BookUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.User", b =>
                {
                    b.HasOne("MartowoKsiazkowo.Encje.Book", null)
                        .WithMany("User")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.UserAddress", b =>
                {
                    b.HasOne("MartowoKsiazkowo.Encje.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("MartowoKsiazkowo.Encje.UserAddress", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.Book", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.BookInfo", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.BookUser", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MartowoKsiazkowo.Encje.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("BookUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
