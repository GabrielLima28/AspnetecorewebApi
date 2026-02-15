
using AspnetecorewebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AspnetecorewebApi.Cotexto
{
    public class AppDbContext : DbContext


    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// cria um contexto de variavel que vai para o banco de dados 
        /// DbSet é uma coleção de entidades do tipo especificado que pode ser 
        /// consultada do banco de dados e usada para 
        /// salvar instâncias dessas entidades no banco de dados .
        /// </summary>

        public DbSet<Categoria> Categoria { get; set; }
                public DbSet<Produto> Produto { get; set; }
    }
}
