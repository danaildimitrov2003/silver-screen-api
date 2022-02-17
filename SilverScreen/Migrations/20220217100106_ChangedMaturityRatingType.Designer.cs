﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilverScreen.Models.Tables;

namespace SilverScreen.Migrations
{
    [DbContext(typeof(SilverScreenContext))]
    [Migration("20220217100106_ChangedMaturityRatingType")]
    partial class ChangedMaturityRatingType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("SilverScreen.Models.Tables.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MovieId" }, "CMovieID");

                    b.HasIndex(new[] { "UserId" }, "CUserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.EfmigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__EFMigrationsHistory");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<int>("UserId1")
                        .HasColumnType("int")
                        .HasColumnName("UserID1");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "UsersFriendFK1");

                    b.HasIndex(new[] { "UserId1" }, "UsersFriendFK2");

                    b.ToTable("FriendList");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Genre1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Genre");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("IMDB_ID");

                    b.Property<bool>("IsSeries")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MaturityRating")
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("NetflixUrl")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NetflixURL");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ImdbId" }, "IMDB_U")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("GenreID");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.HasKey("GenreId", "MovieId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MovieId" }, "MMovieFK");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MovieId" }, "MNMovieFK");

                    b.HasIndex(new[] { "UserId" }, "MNUserFK");

                    b.ToTable("MovieNotifications");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MovieId" }, "MRMovieFK");

                    b.HasIndex(new[] { "UserId" }, "MRUserFK");

                    b.ToTable("MovieRating");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieStaff", b =>
                {
                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.HasKey("StaffId", "MovieId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MovieId" }, "SMovieFK");

                    b.ToTable("MovieStaff");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MyList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<bool>("Watched")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MovieId" }, "MLMovieFK");

                    b.HasIndex(new[] { "UserId" }, "MLUserFK");

                    b.ToTable("MyList");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AuthorID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieID");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("enum('TextOnly','FriendRequest')");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AuthorId" }, "NAuthorFK");

                    b.HasIndex(new[] { "MovieId" }, "NMovieFK");

                    b.HasIndex(new[] { "UserId" }, "NUserFK");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("Banned")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "EmailUIndex")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UsernameUIndex")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("enum('Writer','Director','Actor','')");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Comment", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("CMovieID")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("CUserID")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.FriendList", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("FriendListUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("UsersFriendFK1")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.User", "UserId1Navigation")
                        .WithMany("FriendListUserId1Navigations")
                        .HasForeignKey("UserId1")
                        .HasConstraintName("UsersFriendFK2")
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserId1Navigation");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieGenre", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("GGenreFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("MMovieFK")
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieNotification", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("MovieNotifications")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("MNMovieFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("MovieNotifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("MNUserFK")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieRating", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("MovieRatings")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("MRMovieFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("MovieRatings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("MRUserFK")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MovieStaff", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("MovieStaffs")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("SMovieFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.staff", "Staff")
                        .WithMany("MovieStaffs")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("MStaffFK")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.MyList", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("MyLists")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("MLMovieFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("MyLists")
                        .HasForeignKey("UserId")
                        .HasConstraintName("MLUserFK")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Notification", b =>
                {
                    b.HasOne("SilverScreen.Models.Tables.User", "Author")
                        .WithMany("NotificationAuthors")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("NAuthorFK")
                        .IsRequired();

                    b.HasOne("SilverScreen.Models.Tables.Movie", "Movie")
                        .WithMany("Notifications")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("NMovieFK");

                    b.HasOne("SilverScreen.Models.Tables.User", "User")
                        .WithMany("NotificationUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("NUserFK")
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MovieGenres");

                    b.Navigation("MovieNotifications");

                    b.Navigation("MovieRatings");

                    b.Navigation("MovieStaffs");

                    b.Navigation("MyLists");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FriendListUserId1Navigations");

                    b.Navigation("FriendListUsers");

                    b.Navigation("MovieNotifications");

                    b.Navigation("MovieRatings");

                    b.Navigation("MyLists");

                    b.Navigation("NotificationAuthors");

                    b.Navigation("NotificationUsers");
                });

            modelBuilder.Entity("SilverScreen.Models.Tables.staff", b =>
                {
                    b.Navigation("MovieStaffs");
                });
#pragma warning restore 612, 618
        }
    }
}