﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceRedirectServer.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NiceRedirectServer.Migrations
{
    [DbContext(typeof(RedirectContext))]
    [Migration("20210619160101_newdb")]
    partial class newdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NiceRedirectServer.Models.Redirect", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("Redirect");
                });

            modelBuilder.Entity("NiceRedirectServer.Models.Redirect", b =>
                {
                    b.OwnsOne("NiceRedirectServer.Models.RedirectData", "RedirectData", b1 =>
                        {
                            b1.Property<string>("RedirectKey")
                                .HasColumnType("text");

                            b1.Property<string>("Password")
                                .HasColumnType("text");

                            b1.Property<string>("Target")
                                .HasColumnType("text");

                            b1.Property<byte>("Type")
                                .HasColumnType("smallint");

                            b1.HasKey("RedirectKey");

                            b1.ToTable("Redirect");

                            b1.WithOwner()
                                .HasForeignKey("RedirectKey");
                        });

                    b.Navigation("RedirectData");
                });
#pragma warning restore 612, 618
        }
    }
}
