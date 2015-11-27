using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using App.Data;

namespace App.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20151124204545_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("App.Models.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(255)");

                    b.Property<short?>("ParentCategoryId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(65536)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<int?>("ParentCommentId");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Comments");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(4096)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<short?>("LibraryId");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Faqs");
                });

            modelBuilder.Entity("App.Models.Identity.ApplicationRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("App.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("App.Models.Library", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "char(3)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Url")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(512)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Libraries");
                });

            modelBuilder.Entity("App.Models.LibraryItemAction", b =>
                {
                    b.Property<int>("LibraryItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<short?>("Rating");

                    b.Property<string>("UserAgent");

                    b.Property<string>("UserId");

                    b.HasKey("LibraryItemId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(65536)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<short?>("LibraryId");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Posts");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<short>("CategoryId");

                    b.HasKey("PostId", "CategoryId");

                    b.HasAnnotation("Relational:TableName", "PostCategories");
                });

            modelBuilder.Entity("App.Models.Profile", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(64)");

                    b.Property<string>("PictureLarge");

                    b.Property<string>("PictureMedium");

                    b.Property<string>("PictureSmall");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "nvarchar(128)");

                    b.HasKey("UserId");

                    b.HasAnnotation("Relational:TableName", "Profiles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("App.Models.Category", b =>
                {
                    b.HasOne("App.Models.Category")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.HasOne("App.Models.Comment")
                        .WithMany()
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("App.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.HasOne("App.Models.Library")
                        .WithMany()
                        .HasForeignKey("LibraryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Library", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.LibraryItemAction", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.HasOne("App.Models.Library")
                        .WithMany()
                        .HasForeignKey("LibraryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.HasOne("App.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("App.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("App.Models.Profile", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithOne()
                        .HasForeignKey("App.Models.Profile", "UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
