using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using App.Data;

namespace App.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540");

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
                        .Required()
                        .Annotation("Relational:ColumnType", "nvarchar(255)");

                    b.Property<short?>("ParentCategoryId");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .Required()
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

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Comments");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .Required()
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
                        .Required()
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Faqs");
                });

            modelBuilder.Entity("App.Models.Identity.ApplicationRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .Annotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .Annotation("MaxLength", 256);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Key("Id");

                    b.Index("NormalizedName")
                        .Annotation("Relational:Name", "RoleNameIndex");

                    b.Annotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("App.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken();

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

                    b.Key("Id");

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
                        .Required()
                        .Annotation("Relational:ColumnType", "char(3)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<DateTime?>("DeletedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Description")
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Name")
                        .Required()
                        .Annotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("Url")
                        .Annotation("Relational:ColumnType", "nvarchar(512)");

                    b.Property<string>("UserId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Libraries");
                });

            modelBuilder.Entity("App.Models.LibraryItemAction", b =>
                {
                    b.Property<int>("LibraryItemId");

                    b.Property<int?>("ActionLibraryItemId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<short?>("Rating");

                    b.Property<string>("UserAgent");

                    b.Property<string>("UserId");

                    b.Key("LibraryItemId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .Required()
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
                        .Required()
                        .Annotation("Relational:ColumnType", "nvarchar(1024)");

                    b.Property<string>("Title")
                        .Required()
                        .Annotation("Relational:ColumnType", "nvarchar(128)");

                    b.Property<DateTime?>("UpdatedAt")
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Property<string>("UserId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Posts");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Property<short>("PostId");

                    b.Property<short>("CategoryId");

                    b.Property<int?>("PostId1");

                    b.Key("PostId", "CategoryId");

                    b.Annotation("Relational:TableName", "PostCategories");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId");

                    b.Key("LoginProvider", "ProviderKey");

                    b.Annotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Key("UserId", "RoleId");

                    b.Annotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("App.Models.Category", b =>
                {
                    b.Reference("App.Models.Category")
                        .InverseCollection()
                        .ForeignKey("ParentCategoryId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Comment", b =>
                {
                    b.Reference("App.Models.Comment")
                        .InverseCollection()
                        .ForeignKey("ParentCommentId");

                    b.Reference("App.Models.Post")
                        .InverseCollection()
                        .ForeignKey("PostId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Reference("App.Models.Library")
                        .InverseCollection()
                        .ForeignKey("LibraryId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Library", b =>
                {
                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.LibraryItemAction", b =>
                {
                    b.Reference("App.Models.LibraryItemAction")
                        .InverseCollection()
                        .ForeignKey("ActionLibraryItemId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.Reference("App.Models.Library")
                        .InverseCollection()
                        .ForeignKey("LibraryId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Reference("App.Models.Category")
                        .InverseCollection()
                        .ForeignKey("CategoryId");

                    b.Reference("App.Models.Post")
                        .InverseCollection()
                        .ForeignKey("PostId1");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Reference("App.Models.Identity.ApplicationRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Reference("App.Models.Identity.ApplicationRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");

                    b.Reference("App.Models.Identity.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });
        }
    }
}
