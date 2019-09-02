using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //chave primária
            builder.HasKey(f => new { f.IdFuncionario });

            //campos
            builder.Property(f => f.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(f => f.Salario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
