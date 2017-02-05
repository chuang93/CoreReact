using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreReact.Data;

namespace CoreReact.Migrations
{
    [DbContext(typeof(PlayerProfileDbContext))]
    [Migration("20170205094754_Added more stat categories")]
    partial class Addedmorestatcategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreReact.Models.PlayerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ApgInLoss");

                    b.Property<double>("ApgInWin");

                    b.Property<double>("FgPerInLoss");

                    b.Property<double>("FgPerInWin");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PlayerId");

                    b.Property<double>("PpgInLoss");

                    b.Property<double>("PpgInWin");

                    b.Property<double>("RpgInLoss");

                    b.Property<double>("RpgInWin");

                    b.Property<double>("ThreePerInLoss");

                    b.Property<double>("ThreePerInWin");

                    b.Property<double>("ToPgInLoss");

                    b.Property<double>("ToPgInWin");

                    b.HasKey("Id");

                    b.ToTable("PlayerProfile");
                });
        }
    }
}
