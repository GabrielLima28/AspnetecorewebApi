using AspnetecorewebApi.Cotexto;
using AspnetecorewebApi.Model;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace AspnetecorewebApi.Repository
{
    public class ProdutoRepository : IprodutoRepository
        //

    {
        private readonly AppDbContext Context;
        public ProdutoRepository(AppDbContext context)
        {
            Context = context;
        }
        public IQueryable<Produto> GetProdutos()
        {
            return Context.Produtos;

        }
        public Produto GetProduto(int id)
        {
            return Context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        }
        public Produto Create(Produto produto)
        {
            if (produto is null)
                throw new ArgumentException(nameof(produto));
            Context.Produtos.Add(produto);
            Context.SaveChanges();
            return produto;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto">
        /// Utilizando delegados para retornar true ou falso
        /// na parte de atualização e a exclusão 
        /// 
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool Update(Produto produto)
        {
            Func<bool> retornasvalores = () =>
            {
                return produto is null ? false :
                (Context.Produtos.Entry(produto)
                .State = EntityState.Modified, true).Item2;
            };
            return retornasvalores();
        }
        public bool Delete(int id)
        {

            Func<bool> retornavalor = () =>
            {
                var resutl = Context.Produtos.FirstOrDefault(p =>

                   p.ProdutoId.Equals(id));
                return resutl is null ? false : 
                (Context.Remove(resutl), Context.SaveChanges(), true).Item3;

            };
            return retornavalor();

        }
    }
}
