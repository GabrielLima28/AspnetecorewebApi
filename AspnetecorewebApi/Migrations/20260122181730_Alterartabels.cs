using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetecorewebApi.Migrations
{
    /// <inheritdoc />
    public partial class Alterartabels : Migration
    {
        /// <inheritdoc />
        ///<summary>
        ///classe responsavel por migrar ou gruadar valores no banco de dados 
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nombre, IMagemUrl) Values('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nombre, IMagemUrl) Values('Lanches','lanches.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nombre, IMagemUrl) Values('Sobremesas','Sobremesas.jpg')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");

        }
    }
}
