using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using App.Data;

namespace App.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20151109075610_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964");

            modelBuilder.Entity("App.Models.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(255)");

                    b.Property<short?>("ParentCategoryId");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(65536)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<int?>("ParentCommentId");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "Comments");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(4096)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<short?>("LibraryId");

                    b.Property<string>("Question")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "Faqs");
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
                        .Annotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .Annotation("MaxLength", 256);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.Index("NormalizedName")
                        .Annotation("Relational:Name", "RoleNameIndex");

                    b.Annotation("Relational:TableName", "AspNetRoles");
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
                        .Annotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .Annotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .Annotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UserName")
                        .Annotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.Index("NormalizedEmail")
                        .Annotation("Relational:Name", "EmailIndex");

                    b.Index("NormalizedUserName")
                        .Annotation("Relational:Name", "UserNameIndex");

                    b.Annotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("App.Models.Library", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "char(3)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Url")
                        .Annotation("Relational:ColumnType", "nvarchar(512)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "Libraries");
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
                        .Annotation("Relational:ColumnType", "nvarchar(65536)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<short?>("LibraryId");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "Posts");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<short>("CategoryId");

                    b.HasKey("PostId", "CategoryId");

                    b.Annotation("Relational:TableName", "PostCategories");
                });

            modelBuilder.Entity("App.Models.Profile", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(64)");

                    b.Property<string>("PictureLarge");

                    b.Property<string>("PictureMedium");

                    b.Property<string>("PictureSmall");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .Annotation("Relational:ColumnType", "nvarchar(128)");

                    b.HasKey("UserId");

                    b.Annotation("Relational:TableName", "Profiles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.Annotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.Annotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("App.Models.Category", b =>
                {
                    b.HasOne("App.Models.Category")
                        .WithMany()
                        .ForeignKey("ParentCategoryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.HasOne("App.Models.Comment")
                        .WithMany()
                        .ForeignKey("ParentCommentId");

                    b.HasOne("App.Models.Post")
                        .WithMany()
                        .ForeignKey("PostId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.HasOne("App.Models.Library")
                        .WithMany()
                        .ForeignKey("LibraryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Library", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.LibraryItemAction", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.HasOne("App.Models.Library")
                        .WithMany()
                        .ForeignKey("LibraryId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.HasOne("App.Models.Category")
                        .WithMany()
                        .ForeignKey("CategoryId");

                    b.HasOne("App.Models.Post")
                        .WithMany()
                        .ForeignKey("PostId");
                });

            modelBuilder.Entity("App.Models.Profile", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithOne()
                        .ForeignKey("App.Models.Profile", "UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationRole")
                        .WithMany()
                        .ForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("App.Models.Identity.ApplicationRole")
                        .WithMany()
                        .ForeignKey("RoleId");

                    b.HasOne("App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });
        }
    }
}
