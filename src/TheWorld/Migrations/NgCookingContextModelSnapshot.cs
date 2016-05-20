using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using NgCooking.Models;

namespace TheWorld.Migrations
{
    [DbContext(typeof(NgCookingContext))]
    partial class NgCookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NgCooking.Models.Categories", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.Property<string>("nameToSisplay");

                    b.HasKey("id");
                });

            modelBuilder.Entity("NgCooking.Models.Comments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Recettesid");

                    b.Property<string>("comment");

                    b.Property<int>("mark");

                    b.Property<string>("title");

                    b.Property<int?>("userid");

                    b.HasKey("id");
                });

            modelBuilder.Entity("NgCooking.Models.Communaute", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bio");

                    b.Property<int>("birth");

                    b.Property<string>("city");

                    b.Property<string>("email");

                    b.Property<string>("firstname");

                    b.Property<int>("level");

                    b.Property<string>("password");

                    b.Property<string>("picture");

                    b.Property<string>("surname");

                    b.HasKey("id");
                });

            modelBuilder.Entity("NgCooking.Models.Ingredients", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Recettesid");

                    b.Property<int>("calories");

                    b.Property<int?>("categoryid");

                    b.Property<bool>("isAvailable");

                    b.Property<string>("name");

                    b.Property<string>("picture");

                    b.HasKey("id");
                });

            modelBuilder.Entity("NgCooking.Models.Recettes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("creatorid");

                    b.Property<bool>("isAvailable");

                    b.Property<string>("name");

                    b.Property<string>("nameToDisplay");

                    b.Property<string>("picture");

                    b.Property<string>("preparation");

                    b.HasKey("id");
                });

            modelBuilder.Entity("NgCooking.Models.Comments", b =>
                {
                    b.HasOne("NgCooking.Models.Recettes")
                        .WithMany()
                        .HasForeignKey("Recettesid");

                    b.HasOne("NgCooking.Models.Communaute")
                        .WithMany()
                        .HasForeignKey("userid");
                });

            modelBuilder.Entity("NgCooking.Models.Ingredients", b =>
                {
                    b.HasOne("NgCooking.Models.Recettes")
                        .WithMany()
                        .HasForeignKey("Recettesid");

                    b.HasOne("NgCooking.Models.Categories")
                        .WithMany()
                        .HasForeignKey("categoryid");
                });

            modelBuilder.Entity("NgCooking.Models.Recettes", b =>
                {
                    b.HasOne("NgCooking.Models.Communaute")
                        .WithMany()
                        .HasForeignKey("creatorid");
                });
        }
    }
}
