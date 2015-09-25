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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Key("Id");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<short>("LibraryId");

                    b.Property<string>("Question");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Key("Id");
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
                        .ValueGeneratedOnAddOrUpdate()
                        .Annotation("Relational:ColumnType", "datetime");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Libraries");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<short>("LibraryId");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Key("Id");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<short>("CategoryId");

                    b.Key("PostId", "CategoryId");

                    b.Annotation("Relational:TableName", "PostCategories");
                });

            modelBuilder.Entity("App.Models.FAQ", b =>
                {
                    b.Reference("App.Models.Library")
                        .InverseCollection()
                        .ForeignKey("LibraryId");
                });

            modelBuilder.Entity("App.Models.Post", b =>
                {
                    b.Reference("App.Models.Library")
                        .InverseCollection()
                        .ForeignKey("LibraryId");
                });

            modelBuilder.Entity("App.Models.PostCategory", b =>
                {
                    b.Reference("App.Models.Category")
                        .InverseCollection()
                        .ForeignKey("CategoryId");

                    b.Reference("App.Models.Post")
                        .InverseCollection()
                        .ForeignKey("PostId");
                });
        }
    }
}
