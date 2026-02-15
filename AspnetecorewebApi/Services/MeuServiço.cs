using AspnetecorewebApi.Cotexto;
using Microsoft.EntityFrameworkCore;

namespace AspnetecorewebApi.Services
{
    public class MeuServiço : IMeuServico
    {

        private  readonly AppDbContext contextes; 

        public MeuServiço (AppDbContext context)
        {
            this.contextes = context;
        }
        public string Saudacao(string nome)
        {
            return $"Be-vindo, {nome} \n\n {DateTime.UtcNow}";


        }
        public int bucaid(int id)
        {
            return id;
        }

        //retornando uma lista de produtos 

        public List<Model.Produto> produtos(Model.Produto produto)
        {
            var produtosretorno =  contextes.Produto.ToList();

            return  produtosretorno;

        }
    }
}
