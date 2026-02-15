using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetecorewebApi.Migrations
{
    /// <inheritdoc />
    public partial class Alteraprodutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" + 
                                "Values ('Coca-cola Lata', 'Refrigerante Coca-cola Lata 350ml', 5.00, 'coca-cola-lata.jpg' , 1, NOW(), 1)");
            migrationBuilder.Sql("Insert into Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" + 
                                "Values ('Pepis', 'Refrigerante Pepis Lata 5000ml', 9.00, 'Pepis.jpg' , 2, NOW(), 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produto ");

        }
    }
}
