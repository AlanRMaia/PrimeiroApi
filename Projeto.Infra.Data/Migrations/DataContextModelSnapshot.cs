﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Infra.Data.Context;

namespace Projeto.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto.Domain.Entities.Dependente", b =>
                {
                    b.Property<Guid>("IdDependente")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<Guid>("IdFuncionario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("IdDependente");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("Dependente");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("IdFuncionario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdFuncionario");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Dependente", b =>
                {
                    b.HasOne("Projeto.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Dependentes")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}