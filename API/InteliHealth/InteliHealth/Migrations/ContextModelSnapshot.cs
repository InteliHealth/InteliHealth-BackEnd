﻿// <auto-generated />
using System;
using InteliHealth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InteliHealth.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InteliHealth.Domains.Lembrete", b =>
                {
                    b.Property<int>("IdLembrete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTopico")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLembrete");

                    b.HasIndex("IdTopico");

                    b.ToTable("Lembrete");
                });

            modelBuilder.Entity("InteliHealth.Domains.Resposta", b =>
                {
                    b.Property<int>("IdResposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTopico")
                        .HasColumnType("int");

                    b.Property<bool>("Realizado")
                        .HasColumnType("bit");

                    b.HasKey("IdResposta");

                    b.HasIndex("IdTopico");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("InteliHealth.Domains.Topico", b =>
                {
                    b.Property<int>("IdTopico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTopico");

                    b.ToTable("Topico");
                });

            modelBuilder.Entity("InteliHealth.Domains.Lembrete", b =>
                {
                    b.HasOne("InteliHealth.Domains.Topico", "Topico")
                        .WithMany("Lembretes")
                        .HasForeignKey("IdTopico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topico");
                });

            modelBuilder.Entity("InteliHealth.Domains.Resposta", b =>
                {
                    b.HasOne("InteliHealth.Domains.Topico", "Topico")
                        .WithMany("Respostas")
                        .HasForeignKey("IdTopico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topico");
                });

            modelBuilder.Entity("InteliHealth.Domains.Topico", b =>
                {
                    b.Navigation("Lembretes");

                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
