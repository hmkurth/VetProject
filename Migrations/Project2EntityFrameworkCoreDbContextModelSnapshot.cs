﻿// <auto-generated />
using System;
using KurthProject2Vet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KurthProject2Vet.Migrations
{
    [DbContext(typeof(Project2EntityFrameworkCoreDbContext))]
    partial class Project2EntityFrameworkCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KurthProject2Vet.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("PhoneNumber");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("KurthProject2Vet.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Owner")
                        .IsRequired();

                    b.Property<int>("OwnerId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("PetId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("KurthProject2Vet.Models.PetService", b =>
                {
                    b.Property<int>("PetId");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime>("DateRendered");

                    b.HasKey("PetId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PetsServices");
                });

            modelBuilder.Entity("KurthProject2Vet.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageLengthOfService");

                    b.Property<int>("Cost");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("KurthProject2Vet.Models.Pet", b =>
                {
                    b.HasOne("KurthProject2Vet.Models.Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KurthProject2Vet.Models.PetService", b =>
                {
                    b.HasOne("KurthProject2Vet.Models.Pet", "Pet")
                        .WithMany("PetServices")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KurthProject2Vet.Models.Service", "Service")
                        .WithMany("PetServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
