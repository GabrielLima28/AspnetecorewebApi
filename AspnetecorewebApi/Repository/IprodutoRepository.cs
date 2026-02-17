using AspnetecorewebApi.Model;

namespace AspnetecorewebApi.Repository
{
    public interface IprodutoRepository
    {
        //IQueryable, fornece uma consulta para os dados em vez de trazer 
        //os dados da fonte de dados e convertê-los em ua 
        //uma coleção 
        IQueryable<Produto> GetProdutos();
        Produto GetProduto(int id);
        Produto Create(Produto produto);
        bool Update(Produto produto);
        bool Delete(int id);
    }
}
