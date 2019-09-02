using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.HasKey(d => new { d.IdDependente });

            builder.Property(d => d.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(d => d.Funcionario)
                .WithMany(f => f.Dependentes)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
