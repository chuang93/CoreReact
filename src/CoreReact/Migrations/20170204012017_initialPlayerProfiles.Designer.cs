using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreReact.Data;

namespace CoreReact.Migrations
{
    [DbContext(typeof(PlayerProfileDbContext))]
    [Migration("20170204012017_initialPlayerProfiles")]
    partial class initialPlayerProfiles
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

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<double>("PpgInLoss");

                    b.Property<double>("PpgInWin");

                    b.Property<double>("ToPgInLoss");

                    b.Property<double>("ToPgInWin");

                    b.HasKey("Id");

                    b.ToTable("PlayerProfile");
                });
        }
    }
}
