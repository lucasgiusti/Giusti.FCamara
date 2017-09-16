using System.Data.Entity.ModelConfiguration;
using Giusti.FCamara.Model;

namespace Giusti.FCamara.Data.Configuration
{
    public partial class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("Livro");
            else
                this.ToTable("Livro", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.Nome).HasColumnName("Nome");
            this.Property(i => i.Autor).HasColumnName("Autor");
        }
    }
}
