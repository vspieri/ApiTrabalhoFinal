using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CadastroMap : IEntityTypeConfiguration<CadastroModel>
    {
        public void Configure(EntityTypeBuilder<CadastroModel> builder)
        {
            builder.HasKey(x => x.CadastroId);
            builder.Property(x => x.CadastroNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Localidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descrição).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Foto).IsRequired().HasMaxLength(255);


        }
    }
}
